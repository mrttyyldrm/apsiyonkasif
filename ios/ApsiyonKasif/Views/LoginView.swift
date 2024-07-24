//
//  LoginView.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 20.07.2024.
//

import SwiftUI

struct LoginView: View {
    
    @State var email = ""
    @State var password = ""
    @State private var isPasswordVisible = false
    @State var isGuideView = false
    
    @ObservedObject var viewModel = LoginViewModel()
    
    var body: some View {
        NavigationStack {
            ZStack {
                VStack {
                    HStack {
                        Image("iconPrimary")
                            .resizable()
                            .scaledToFit()
                            .frame(width: 65, height: 65)
                        
                        Spacer()
                        
                        Text("Öncelikle Apsiyon hesabına \n giriş yapalım!")
                            .font(.customFont(.semiBold, fontSize: 14))
                            .frame(width: 253, height: 65)
                            .foregroundColor(.customWhite)
                            .background(Color.bgBlue)
                            .cornerRadius(10, corner: [.bottomRight, .topLeft, .topRight])
                    }
                    .safeAreaPadding()
                    Spacer()
                    
                    VStack {
                        Text("Giriş Yap")
                            .font(.customFont(.extraBold, fontSize: 32))
                            .foregroundColor(Color.titleBlue)
                            .padding(.bottom, 8)
                        
                        Text("Apsiyon platform hesabınızla")
                            .font(.customFont(.medium, fontSize: 16))
                            .foregroundColor(Color.explanationBlue)
                        
                        Text("giriş yaparak kullanmaya başlayın!")
                            .font(.customFont(.medium, fontSize: 16))
                            .foregroundColor(Color.explanationBlue)
                    }
                    .padding(.bottom, 50)
                    
                    VStack {
                        // E-Mail TextField
                        Text("E-Mail")
                            .font(.customFont(.bold, fontSize: 14))
                            .foregroundColor(Color.titleBlue)
                            .frame(maxWidth: .infinity, alignment: .leading)
                        
                        TextField("E-Mail giriniz", text: $email)
                            .font(.customFont(.medium, fontSize: 16))
                            .keyboardType(.emailAddress)
                            .padding(20)
                            .foregroundColor(.explanationBlue)
                            .frame(width: 330, height: 49)
                            .background(Color.customWhite)
                            .cornerRadius(10)
                            .padding(.bottom, 20)
                        
                        // Password TextField
                        Text("Parola")
                            .font(.customFont(.bold, fontSize: 14))
                            .foregroundColor(Color.titleBlue)
                            .frame(maxWidth: .infinity, alignment: .leading)
                        
                        ZStack(alignment: .trailing) {
                            if isPasswordVisible {
                                TextField("Parola giriniz", text: $password)
                                    .font(.customFont(.medium, fontSize: 16))
                                    .padding()
                                    .foregroundColor(.explanationBlue)
                                    .frame(width: 330, height: 49)
                                    .background(Color.customWhite)
                                    .cornerRadius(10)
                            } else {
                                SecureField("Parola giriniz", text: $password)
                                    .font(.customFont(.medium, fontSize: 16))
                                    .padding()
                                    .foregroundColor(.explanationBlue)
                                    .frame(width: 330, height: 49)
                                    .background(Color.customWhite)
                                    .cornerRadius(10)
                            }
                            
                            Button(action: {
                                isPasswordVisible.toggle()
                            }) {
                                Image(systemName: isPasswordVisible ? "eye.slash" : "eye")
                                    .foregroundColor(.gray)
                                    .padding(.trailing, 20)
                            }
                        }
                    }
                    
                    Spacer()
                    
                    if let error = viewModel.error {
                        Text(error)
                            .foregroundColor(.red)
                            .padding()
                    }
                    
                    NavigationLink(destination: GuideView(), isActive: $isGuideView) {
                        Button(action: {
                            viewModel.login(email: email, password: password) {
                                isGuideView = true
                            }
                        }) {
                            Text("Giriş Yap")
                                .font(.system(size: 16, weight: .bold))
                                .foregroundColor(.customWhite)
                                .frame(width: 327, height: 48)
                                .background(Color.bgBlue)
                                .cornerRadius(8.0)
                        }
                    }
                }
                .background(Color.bg)
                .padding(.all, 30)
                .toolbar {
                    ToolbarItemGroup(placement: .keyboard) {
                        Spacer()
                        Button("Bitti") {
                            hideKeyboard()
                        }
                    }
                }
            }
            .background(Color.bg)
        }
        .navigationBarHidden(true)
        .navHide
        
    }
    
    private func hideKeyboard() {
        UIApplication.shared.sendAction(#selector(UIResponder.resignFirstResponder), to: nil, from: nil, for: nil)
    }
}

#Preview {
    LoginView()
}
