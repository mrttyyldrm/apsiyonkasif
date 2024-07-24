//
//  LoginViewModel.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 21.07.2024.
//

import Foundation
import RxSwift
import Combine

//class LoginViewModel: ObservableObject {
//    private let loginService = LoginRepo()
//    private let disposeBag = DisposeBag()
//
//    @Published var error: String?
//
//    func login(email: String, password: String) {
//        loginService.login(email: email, password: password)
//            .observe(on: MainScheduler.instance)
//            .subscribe { result in
//                switch result {
//                case .success(let token):
//                    print("Token: \(token)")
//                    // Burada token'ı kaydedebilir veya gerekli işlemleri yapabilirsiniz.
//                case .failure(let error):
//                    self.error = error.localizedDescription
//                }
//            }
//            .disposed(by: disposeBag)
//    }
//}

class LoginViewModel: ObservableObject {
    var lrepo = LoginRepo()
    var login = BehaviorSubject<[Login]>(value: [Login]())
    
    @Published var error: String?

    func login(email: String, password: String, completion: @escaping () -> Void) {
//         Giriş işlemi burada yapılacak
//         Eğer giriş başarılıysa:
         completion()

//         Eğer giriş başarısızsa:
         self.error = "Giriş başarısız"
    }
}

