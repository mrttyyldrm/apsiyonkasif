//
//  NeighbourhoodView.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 23.07.2024.
//

import SwiftUI

struct NeighbourhoodView: View {
    var selectedCity: String?
    var selectedDistrict: String?
    @State private var selectedNeighbourhood: String? = nil
    @State private var navigateToFilters = false
    
    let neighbourhoods = ["Yunusemre", "Bahçelievler", "Meydan", "Gaybiefendi", "Dumlupınar", "Fatih", "Zafertepe"]
    
    var body: some View {
        NavigationStack {
            ZStack {
                Color.bg
                    .ignoresSafeArea()
                
                SearchHeader(value: 0.8, text: "Pekala, arama yapmak istediğin\nlokasyon nedir?")
                    .padding(.bottom, 100)
                
                VStack {
                    Spacer()
                    
                    Text("Mahalle Seçimi")
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
                            .padding(.bottom, 10)
                        
                        Text(selectedDistrict ?? "")
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
                            ForEach(neighbourhoods, id: \.self) { neighbourhood in
                                Button(action: {
                                    selectedNeighbourhood = neighbourhood
                                    navigateToFilters = true
                                }) {
                                    Text(neighbourhood)
                                        .font(.customFont(.extraBold, fontSize: 16))
                                        .maxLeft
                                        .padding(20)
                                        .background(selectedNeighbourhood == neighbourhood ? Color.bgBlue : Color.customWhite)
                                        .foregroundColor(selectedNeighbourhood == neighbourhood ? .customWhite : .titleBlue)
                                        .cornerRadius(10)
                                }
                                .buttonStyle(PlainButtonStyle())
                            }
                        }
                        .padding(.horizontal, 30)
                    }
                    
                    Spacer()
                }
            }
            .background(
                NavigationLink(
                    destination: FiltersView(),
                    isActive: $navigateToFilters,
                    label: { EmptyView() }
                )
                .hidden()
            )
        }
    }
}
#Preview {
    NeighbourhoodView()
}
