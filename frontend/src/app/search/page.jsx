"use client";

import React, { useState, useEffect } from "react";
import "@/styles/pages/search.scss";
import Information from "@/components/Information";
import Progress from "@/components/Progress";
import Error from "@/components/Error";
import Button from "@/components/Button";
import Control from "@/components/Control";
import { IsLogged, GetCity, GetCounty, GetDistrict } from "@/api";
import { useRouter } from "next/navigation";

function Search() {
  const router = useRouter();

  const [step, setStep] = useState({
    count: 1,
    ratio: "20%",
    information: "Aramak istediğin ilan türü ile başlayalım.",
    title: "İlan Türü",
  });

  const [error, setError] = useState({
    situation: false,
    text: null,
  });

  const [history, setHistory] = useState([]);
  const [cities, setCities] = useState([]);
  const [counties, setCounties] = useState([]);
  const [districts, setDistricts] = useState([]);

  const [params, setParams] = useState({
    advertTypeId: null,
    cityId: null,
    countyId: null,
    districtId: null,
  });

  const handleIsLogged = async () => {
    try {
      await IsLogged(localStorage.getItem("token"));
    } catch (error) {
      router.push("/login");
    }
  };

  useEffect(() => {
    handleIsLogged();
  }, []);

  const selectType = (id) => {
    setParams((previous) => ({ ...previous, advertTypeId: id }));
    setStep((previous) => ({ ...previous, count: 0 }));
    handleGetCity();
  };

  const handleGetCity = async () => {
    try {
      const data = await GetCity();
      setCities(data);
      setStep({
        count: 2,
        ratio: "40%",
        information: "Pekala, arama yapmak istediğin il nedir?",
        title: "İl Seçimi",
      });
    } catch (error) {
      setError({
        situation: true,
        text: "İl listeleme sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  const selectCity = (id, name) => {
    setParams((previous) => ({ ...previous, cityId: id }));
    const city = {
      id: id,
      name: name,
    };
    handleGetCounty(id);
    setHistory((previous) => [...previous, city]);
  };

  const handleGetCounty = async (id) => {
    try {
      const data = await GetCounty(id);
      setCities([]);
      setCounties(data);
      setStep({
        count: 2,
        ratio: "60%",
        information: "Peki, arama yapmak istediğin ilçe nedir?",
        title: "İlçe Seçimi",
      });
    } catch (error) {
      setError({
        situation: true,
        text: "İlçe listeleme sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  const selectCounty = (id, name) => {
    setParams((previous) => ({ ...previous, countyId: id }));
    const county = {
      id: id,
      name: name,
    };
    handleGetDistrict(id);
    setHistory((previous) => [...previous, county]);
  };

  const handleGetDistrict = async (id) => {
    try {
      const data = await GetDistrict(id);
      setCounties([]);
      setDistricts(data);
      setStep({
        count: 2,
        ratio: "80%",
        information: "Süper! Peki, arama yapmak istediğin mahalle nedir?",
        title: "Mahalle Seçimi",
      });
    } catch (error) {
      setError({
        situation: true,
        text: "Mahalle listeleme sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  const selectDistrict = (id, name) => {
    params.districtId = id;
    setStep({
      count: 3,
      ratio: "100%",
      information:
        "Filtreler ile daha keskin arama sonuçları elde edebilirsin!",
      title: "İlan Filtreleri",
    });
  };

  const redirectListing = () => {
    const query = new URLSearchParams();
    for (const [key, value] of Object.entries(params)) {
      if (value !== null && value !== undefined) {
        query.set(key, value);
      }
    }
    router.push(`/listing?${query}`);
  };

  return (
    <>
      {error.situation && <Error text={error.text} />}
      <section id="search">
        <div id="search-progress">
          <Progress ratio={step.ratio}></Progress>
        </div>
        <div id="search-information">
          <Information text={step.information} />
        </div>
        <div id="search-title">
          <h1>{step.title}</h1>
        </div>
        <div id="search-content">
          {step.count === 0 && (
            <article id="loading">
              <i className="fa-solid fa-circle-notch fa-spin"></i>
            </article>
          )}
          {step.count === 1 && (
            <article id="type">
              <div className="type" onClick={() => selectType(1)}>
                <div className="type-icon">
                  <i className="fa-solid fa-house-flag"></i>
                </div>
                <h2>Satılık İlanlar</h2>
              </div>
              <div className="type" onClick={() => selectType(2)}>
                <div className="type-icon">
                  <i className="fa-solid fa-house-chimney-user"></i>
                </div>
                <h2>Kiralık İlanlar</h2>
              </div>
            </article>
          )}
          {step.count === 2 && (
            <article id="location">
              <ul id="location-history">
                {history.map((history) => (
                  <li className="option" key={history.id}>
                    {history.name}
                  </li>
                ))}
              </ul>
              <ul id="location-options">
                {cities.map((city, index) => (
                  <li
                    className="option"
                    key={index}
                    onClick={() => selectCity(city.id, city.name)}
                  >
                    {city.name}
                  </li>
                ))}
                {counties.map((county, index) => (
                  <li
                    className="option"
                    key={index}
                    onClick={() => selectCounty(county.id, county.name)}
                  >
                    {county.name}
                  </li>
                ))}
                {districts.map((district, index) => (
                  <li
                    className="option"
                    key={index}
                    onClick={() => selectDistrict(district.id, district.name)}
                  >
                    {district.name}
                  </li>
                ))}
              </ul>
            </article>
          )}
          {step.count === 3 && (
            <article id="filters">
              <div id="filters-content">
                <div id="filters-overlay">
                  <p>
                    Alpha sürümünde filtre özelliği inaktif durumdadır. İlan Ara
                    butonu ile sürece devam edebilirsiniz.
                  </p>
                </div>
                <div className="filters-line">
                  <hr />
                  <h3>Genel Bilgiler</h3>
                  <hr />
                </div>
                <Control label="Fiyat (düşük)" type="number" rule="₺" />
                <Control label="Fiyat (yüksek)" type="number" rule="₺" />
                <Control label="Bina Yaşı" type="number" />
                <Control label="Aidat" type="number" rule="₺" />
                <Control label="Oda Sayısı" type="number" />
                <Control label="Fiyat (düşük)" type="number" rule="₺" />
                <Control label="Fiyat (yüksek)" type="number" rule="₺" />
                <Control label="Bina Yaşı" type="number" />
                <Control label="Aidat" type="number" rule="₺" />
                <Control label="Oda Sayısı" type="number" />
              </div>
              <div id="filters-button">
                <Button
                  text="İlan Ara"
                  onClickHandler={redirectListing}
                ></Button>
              </div>
            </article>
          )}
        </div>
      </section>
    </>
  );
}

export default Search;
