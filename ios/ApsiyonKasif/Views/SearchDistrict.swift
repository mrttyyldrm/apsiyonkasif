//
//  SearchDistrict.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 23.07.2024.
//

import SwiftUI

struct SearchDistrict: View {
    var selectedCity: String?
    @State private var selectedDistrict: String? = nil
    @State private var navigateToNeighborhood = false
    
    let districties = ["Merkez", "Tavşanlı", "Simav", "Gediz", "Çavdarhisar", "Dumlupınar", "Emet"]
    
    var body: some View {
        
        ZStack{
            Color.bg
                .ignoresSafeArea()
            
            SearchHeader(value: 0.8, text: "Pekala, arama yapmak istediğin\nlokasyon nedir?")
                .padding(.bottom, 100)
            
            VStack {
                Spacer()
                
                Text("İlçe Seçimi")
                    .font(.customFont(.extraBold, fontSize: 32))
                    .padding(.top, 120)
                    .foregroundColor(.titleBlue)
                
                VStack {
                    Text(selectedCity ?? "")
                        .font(.customFont(.extraBold, fontSize: 16))
                        .foregroundColor(.bgBlue)
                        .maxLeft
                        .padding(20)
                        .overlay(
                            RoundedRectangle(cornerRadius: 10)
                                .stroke(Color.btnBlue, lineWidth: 5) // Adjust color and thickness here
                        )
                        .cornerRadius(10)
                        .background(
                            Color.bgBlue
                                .opacity(0.1) // Set your desired opacity here
                                .cornerRadius(10)
                        )
                        .padding(.bottom, 30)
                }
                .padding(.horizontal, 30)
                
                
                ScrollView {
                    VStack(spacing: 20) {
                        ForEach(districties, id: \.self) { district in
                            Button(action: {
                                selectedDistrict = district
                                navigateToNeighborhood = true
                            }) {
                                Text(district)
                                    .font(.customFont(.extraBold, fontSize: 16))
                                    .maxLeft
                                    .padding(20)
                                    .background(selectedDistrict == district ? Color.bgBlue : Color.customWhite)
                                    .foregroundColor(selectedDistrict == district ? .customWhite : .titleBlue)
                                    .cornerRadius(10)
                            }
                            .buttonStyle(PlainButtonStyle())
                        }
                    }
                    .padding(.horizontal, 30)
                }
                
                Spacer()
                
                // NavigationLink for navigation to NeighborhoodView
                NavigationLink(
                    destination: NeighbourhoodView(selectedCity: selectedCity ?? "", selectedDistrict: selectedDistrict ?? ""),
                    isActive: $navigateToNeighborhood
                ) {
                    EmptyView()
                }
            }
        }
    }
}

#Preview {
    SearchDistrict()
}
