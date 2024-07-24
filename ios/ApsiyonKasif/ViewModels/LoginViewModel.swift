//
//  LoginViewModel.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 21.07.2024.
//

import Foundation
import Combine


class LoginViewModel: ObservableObject {
    @Published var error: String?
    @Published var isAuthenticated = false
    
    private var cancellables = Set<AnyCancellable>()
    
    private var session: URLSession = {
        let configuration = URLSessionConfiguration.default
        let session = URLSession(configuration: configuration, delegate: SessionDelegate(), delegateQueue: nil)
        return session
    }()

    func login(email: String, password: String) {
        guard let url = URL(string: "https://api.mlsadpu.com/auth") else { return }
        
        var request = URLRequest(url: url)
        request.httpMethod = "POST"
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        
        let body: [String: String] = ["email": email, "password": password]
        request.httpBody = try? JSONSerialization.data(withJSONObject: body, options: [])
        
        session.dataTaskPublisher(for: request)
            .map { $0.data }
            .decode(type: LoginResponse.self, decoder: JSONDecoder())
            .receive(on: DispatchQueue.main)
            .sink(receiveCompletion: { completion in
                switch completion {
                case .finished:
                    break
                case .failure(let error):
                    self.error = error.localizedDescription
                }
            }, receiveValue: { response in
                if response.token.isEmpty {
                    self.error = "Geçersiz e-posta veya parola"
                } else {
                    print("Token: \(response.token)")
                    self.isAuthenticated = true
                    // Burada token'ı kaydedebilirsiniz
                }
            })
            .store(in: &cancellables)
    }
}

class SessionDelegate: NSObject, URLSessionDelegate {
    func urlSession(_ session: URLSession, didReceive challenge: URLAuthenticationChallenge, completionHandler: @escaping (URLSession.AuthChallengeDisposition, URLCredential?) -> Void) {
        completionHandler(.useCredential, URLCredential(trust: challenge.protectionSpace.serverTrust!))
    }
}

struct LoginResponse: Codable {
    let token: String
}
