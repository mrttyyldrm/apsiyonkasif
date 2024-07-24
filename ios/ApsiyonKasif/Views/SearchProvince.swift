//
//  SearchLocation.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 23.07.2024.
//

import SwiftUI

struct SearchProvince: View {
    
    @State private var selectedCity: String? = nil
    @State private var navigateToDistrict = false
    
    let cities = ["İstanbul", "Kütahya", "Eskişehir", "Bursa", "İzmir", "Ankara", "Sakarya", "Çanakkale"]
    
    var body: some View {
        NavigationStack {
            ZStack{
                Color.bg
                    .ignoresSafeArea()
                
                SearchHeader(value: 0.4, text: "Pekala, arama yapmak istediğin\nlokasyon nedir?")
                    .padding(.bottom, 100)
                
                VStack {
                    Spacer()
                    
                    Text("İl Seçimi")
                        .font(.customFont(.extraBold, fontSize: 32))
                        .padding(.top, 120)
                        .foregroundColor(.titleBlue)
                    
                    ScrollView {
                        VStack(spacing: 20) {
                            ForEach(cities, id: \.self) { city in
                                Button(action: {
                                    selectedCity = city
                                    navigateToDistrict = true
                                }) {
                                    Text(city)
                                        .font(.customFont(.extraBold, fontSize: 16))
                                        .maxLeft
                                        .padding(20)
                                        .background(selectedCity == city ? Color.bgBlue : Color.customWhite)
                                        .foregroundColor(selectedCity == city ? .customWhite : .titleBlue)
                                        .cornerRadius(10)
                                }
                                .buttonStyle(PlainButtonStyle())
                            }
                        }
                        .padding(.horizontal, 30)
                    }
                    
                    Spacer()
                    
                    NavigationLink(
                        destination: SearchDistrict(selectedCity: selectedCity)
                            .navigationBarBackButtonHidden(true),
                        isActive: $navigateToDistrict
                    ) {
                        EmptyView()
                    }
                }
            }
            .navigationBarHidden(true)
        }
    }
}

#Preview {
    SearchProvince()
}
