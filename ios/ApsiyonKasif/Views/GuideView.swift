//
//  GuideView.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 21.07.2024.
//

import SwiftUI

struct GuideView: View {
    
    @State var name: String = "Arda"
    @State private var showSearchHelp: Bool = false
    @State private var showCreateHelp: Bool = false
    @State private var delayedSearchHelpText: Bool = false
    @State private var delayedCreateHelpText: Bool = false
    @State private var showSearch: Bool = false
    @State private var navigateToSearch: Bool = false
    
    var body: some View {
        ZStack {
            
            HeaderView()
            
            VStack {
                Spacer()
                Rectangle()
                    .ignoresSafeArea()
                    .frame(maxWidth: .infinity)
                    .frame(height: 120)
                    .foregroundColor(.bgBlue)
                    .cornerRadius(50, corner: [.topLeft, .topRight])
            }
            
            VStack {
                Spacer()
                VStack {
                    Image("iconPrimary")
                        .resizable()
                        .scaledToFit()
                        .frame(width: 150, height: 150)
                        .padding(.bottom, 35)
                    
                    Text("Apsiyon Kaşif platformuna hoş \n geldin \(name)!")
                        .font(.customFont(.semiBold, fontSize: 16))
                        .foregroundColor(.customWhite)
                        .frame(width: 303, height: 68)
                        .background(Color.bgBlue)
                        .cornerRadius(10, corner: [.bottomRight, .topLeft, .topRight])
                        .frame(maxWidth: .infinity, alignment: .leading)
                        .maxLeft
                        .padding(.bottom, 15)
                        .padding(.horizontal, 30)
                    
                    Text("Sana nasıl yardımcı olabilirim?")
                        .font(.customFont(.semiBold, fontSize: 16))
                        .foregroundColor(.customWhite)
                        .frame(width: 303, height: 44)
                        .background(Color.bgBlue)
                        .cornerRadius(10, corner: [.bottomRight, .topLeft, .topRight])
                        .frame(maxWidth: .infinity, alignment: .leading)
                        .maxLeft
                        .padding(.horizontal, 30)
                        .padding(.bottom, 15)
                    
                    // Conditional Text for Search Help
                    if showSearchHelp {
                        VStack {
                            Text("İlan aramak istiyorum")
                                .font(.customFont(.semiBold, fontSize: 16))
                                .foregroundColor(.btnBlue)
                                .frame(width: 303, height: 44)
                                .background(Color.customWhite)
                                .cornerRadius(10, corner: [.bottomLeft, .topLeft, .topRight])
                                .maxRight
                                .padding(.bottom, 15)
                                .padding(.horizontal, 30)
                                .frame(maxWidth: .infinity, alignment: .leading)
                            
                            if delayedSearchHelpText {
                                Text("Elbette, seni ilan arama adımına yönlendiriyorum.")
                                    .font(.customFont(.medium, fontSize: 16))
                                    .foregroundColor(.customWhite)
                                    .frame(width: 303, height: 68)
                                    .background(Color.bgBlue)
                                    .cornerRadius(10, corner: [.bottomRight, .topLeft, .topRight])
                                    .padding(.horizontal, 30)
                                    .frame(maxWidth: .infinity, alignment: .leading)
                                    .maxLeft
                                    .onAppear {
                                        DispatchQueue.main.asyncAfter(deadline: .now() + 1.0) {
                                            navigateToSearch = true
                                        }
                                    }
                            }
                        }
                        .transition(.opacity)
                        .onAppear {
                            DispatchQueue.main.asyncAfter(deadline: .now() + 2.0) {
                                delayedSearchHelpText = true
                            }
                        }
                    }
                    
                    // Conditional Text for Create Help
                    if showCreateHelp {
                        VStack {
                            Text("İlan oluşturmak istiyorum")
                                .font(.customFont(.semiBold, fontSize: 16))
                                .foregroundColor(.btnBlue)
                                .frame(width: 303, height: 44)
                                .background(Color.customWhite)
                                .cornerRadius(10, corner: [.bottomLeft, .topLeft, .topRight])
                                .maxRight
                                .padding(.bottom, 15)
                                .padding(.horizontal, 30)
                                .frame(maxWidth: .infinity, alignment: .leading)
                            
                            if delayedCreateHelpText {
                                Text("Elbette, seni ilan oluşturma adımına yönlendiriyorum.")
                                    .font(.customFont(.medium, fontSize: 16))
                                    .foregroundColor(.customWhite)
                                    .frame(width: 303, height: 68)
                                    .background(Color.bgBlue)
                                    .cornerRadius(10, corner: [.bottomRight, .topLeft, .topRight])
                                    .padding(.horizontal, 30)
                                    .frame(maxWidth: .infinity, alignment: .leading)
                                    .maxLeft
                                    .onAppear {
                                        DispatchQueue.main.asyncAfter(deadline: .now() + 1.0) {
                                            navigateToSearch = true
                                        }
                                    }
                            }
                        }
                        .transition(.opacity)
                        .onAppear {
                            DispatchQueue.main.asyncAfter(deadline: .now() + 2.0) {
                                delayedCreateHelpText = true
                            }
                        }
                    }
                }
                .padding(.bottom, 100)
                
                Spacer()
                
                HStack {
                    Button(action: {
                        withAnimation {
                            showCreateHelp.toggle()
                            delayedCreateHelpText = false // Reset the delayed text
                            if showSearchHelp {
                                showSearchHelp = false
                                delayedSearchHelpText = false // Reset the delayed text
                            }
                        }
                    }) {
                        if showCreateHelp {
                            Text("İlan oluşturmak istiyorum.")
                                .font(.customFont(.semiBold, fontSize: 16))
                                .foregroundColor(Color.bgBlue)
                                .frame(width: 159, height: 70)
                                .background(Color.customWhite)
                                .cornerRadius(10, corner: [.bottomRight, .topLeft, .topRight])
    
                        } else {
                            Text("İlan oluşturmak istiyorum.")
                                .font(.customFont(.semiBold, fontSize: 16))
                                .foregroundColor(.customWhite)
                                .frame(width: 159, height: 70)
                                .background(Color.btnBlue)
                                .cornerRadius(10, corner: [.bottomRight, .topLeft, .topRight])
                        }
                    }
                    
                    Spacer()
                    
                    Button(action: {
                        withAnimation {
                            showSearchHelp.toggle()
                            delayedSearchHelpText = false // Reset the delayed text
                            if showCreateHelp {
                                showCreateHelp = false
                                delayedCreateHelpText = false // Reset the delayed text
                            }
                        }
                    }) {
                        if showSearchHelp {
                            Text("İlan aramak istiyorum.")
                                .font(.customFont(.semiBold, fontSize: 16))
                                .foregroundColor(Color.bgBlue)
                                .frame(width: 159, height: 70)
                                .background(Color.customWhite)
                                .cornerRadius(10, corner: [.bottomLeft, .topLeft, .topRight])
                        } else {
                            Text("İlan aramak istiyorum.")
                                .font(.customFont(.semiBold, fontSize: 16))
                                .foregroundColor(.customWhite)
                                .frame(width: 159, height: 70)
                                .background(Color.btnBlue)
                                .cornerRadius(10, corner: [.bottomLeft, .topLeft, .topRight])
                        }
                    }
                }
                .padding(.bottom, 30)
                .padding(.horizontal, 30)
            }
            .padding(.top, 50)
        }
        .background(
            NavigationLink(
                destination: SearchView().navigationBarHidden(true),
                isActive: $navigateToSearch,
                label: { EmptyView() }
            )
        )
        .background(Color.bg)
        .navigationBarHidden(true)
        .edgesIgnoringSafeArea([.top, .bottom])
    }
}

#Preview {
    GuideView()
}
