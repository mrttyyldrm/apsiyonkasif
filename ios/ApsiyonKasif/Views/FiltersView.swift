//
//  FiltersView.swift
//  ApsiyonKasif
//
//  Created by Arda Nar on 24.07.2024.
//

import SwiftUI

struct FiltersView: View {
    @State private var minPrice: String = "700.000"
    @State private var maxPrice: String = "1.200.000"
    @State private var buildingAge: String = "7 yıl"
    @State private var dues: String = "300"
    @State private var roomCount: String = "2+1"
    @State private var floor: String = "3. Kat"
    @State private var minArea: String = "85"
    @State private var maxArea: String = "140"
    @State private var furnitureStatus: String = "Eşyalı"
    @State private var heatingType: String = "Doğalgaz"
    
    var body: some View {
        ZStack {
            Color.bg
                .ignoresSafeArea()
            
            SearchHeader(value: 1, text: "İlan filtreleri ile daha keskin\narama sonuçları elde edebilirsin!")
            
            VStack {
                Spacer()
                Rectangle()
                    .frame(maxWidth: .infinity)
                    .frame(height: 125)
                    .foregroundColor(.bgBlue)
                    .cornerRadius(50, corner: [.topLeft, .topRight])
                    .padding(.bottom, -40)
            }
            
            VStack {
                
            
                
                Text("İlan Filtreleri")
                    .font(.customFont(.extraBold, fontSize: 32))
                    .foregroundColor(.titleBlue)
                
                Spacer().frame(height: 30) // 30px boşluk
                
                HStack {
                    Rectangle()
                        .fill(.gray)
                        .frame(width: 104.5, height: 1)
                    Spacer()
                    
                    Text("Genel Bilgiler")
                        .font(.customFont(.medium, fontSize: 14))
                        .foregroundColor(.customGray)
                    
                    Spacer()
                    
                    Rectangle()
                        .fill(.gray)
                        .frame(width: 104.5, height: 1)
                }
                
                ScrollView{
                    
                    VStack{
                        VStack{
                            HStack{
                                VStack(alignment: .leading) {
                                    Text("Fiyat (düşük)")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("700.000", text: $minPrice)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .keyboardType(.numberPad)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                                VStack(alignment: .leading) {
                                    Text("Fiyat (yüksek)")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("1.200.000", text: $maxPrice)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .keyboardType(.numberPad)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                            }
                            
                            HStack(spacing: 16) {
                                VStack(alignment: .leading) {
                                    Text("Bina Yaşı")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("7 yıl", text: $buildingAge)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                                VStack(alignment: .leading) {
                                    Text("Aidat")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("300", text: $dues)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .keyboardType(.numberPad)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                            }
                            
                            HStack(spacing: 16) {
                                VStack(alignment: .leading) {
                                    Text("Oda Sayısı")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("2+1", text: $roomCount)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                                VStack(alignment: .leading) {
                                    Text("Bulunduğu Kat")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("3. Kat", text: $floor)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                            }
                            
                            HStack(spacing: 16) {
                                VStack(alignment: .leading) {
                                    Text("Net m² (düşük)")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("85", text: $minArea)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .keyboardType(.numberPad)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                                VStack(alignment: .leading) {
                                    Text("Net m² (yüksek)")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("140 ", text: $maxArea)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .keyboardType(.numberPad)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                            }
                            
                            HStack(spacing: 16) {
                                VStack(alignment: .leading) {
                                    Text("Eşya Durumu")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("Eşyalı", text: $furnitureStatus)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                                VStack(alignment: .leading) {
                                    Text("Isınma Tipi")
                                        .font(.customFont(.bold, fontSize: 14))
                                        .foregroundColor(.titleBlue)
                                    TextField("Doğalgaz", text: $heatingType)
                                        .font(.customFont(.medium, fontSize: 16))
                                        .foregroundColor(.customGray)
                                        .textFieldStyle(RoundedBorderTextFieldStyle())
                                }
                            }
                        }
                        .padding(10)
                        .cornerRadius(10)
                    }
                    .padding(30)
                    
                    VStack{
                        
                        Button(action: {
                            
                        }, label: {
                            Text("İlan Ara")
                                .font(.system(size: 16, weight: .bold))
                                .foregroundColor(.customWhite)
                        })
                        .frame(width: 327, height: 48)
                        .background(Color.btnBlue)
                        .cornerRadius(8.0)
                        .padding(.top, 50)
                    }
                    
                }
                
                Spacer()
            }
            .padding(.top, 140)
        }
    }
}

struct FiltersView_Previews: PreviewProvider {
    static var previews: some View {
        FiltersView()
    }
}
