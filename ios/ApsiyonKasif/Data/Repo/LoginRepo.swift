//
//  LoginRepo.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 21.07.2024.
//

import Foundation
import Alamofire
import RxSwift

class LoginRepo {
    
    func login(email: String, password: String) -> Observable<Result<String, Error>> {
        let url = "https://apsiyonkasif.mlsadpu.com"
        let parameters: [String: String] = [
            "email": email,
            "password": password
        ]

        return Observable.create { observer in
            AF.request(url, method: .post, parameters: parameters, encoding: JSONEncoding.default)
                .responseJSON { response in
                    switch response.result {
                    case .success(let data):
                        if let json = data as? [String: Any],
                           let token = json["token"] as? String {
                            observer.onNext(.success(token))
                        } else {
                            observer.onNext(.failure(NSError(domain: "", code: -1, userInfo: [NSLocalizedDescriptionKey: "Invalid response"])))
                        }
                    case .failure(let error):
                        observer.onNext(.failure(error))
                    }
                    observer.onCompleted()
                }

            return Disposables.create()
        }
    }
}

