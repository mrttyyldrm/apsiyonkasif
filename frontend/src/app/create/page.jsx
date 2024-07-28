"use client";

import React, { useState, useEffect } from "react";
import "@/styles/pages/create.scss";
import Loading from "@/components/Loading";
import Information from "@/components/Information";
import Progress from "@/components/Progress";
import Control from "@/components/Control";
import Select from "@/components/Select";
import Button from "@/components/Button";
import Bar from "@/components/Bar";
import Card from "@/components/Card";
import Error from "@/components/Error";
import Success from "@/components/Success";
import { IsLogged, GetHomes, CreateAd } from "@/api";

function Create() {
  const [cards, setCards] = useState([]);
  const [filteredCards, setFilteredCards] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [buttonLoading, setButtonLoading] = useState(false);
  const [error, setError] = useState({
    situation: false,
    text: null,
  });
  const [success, setSuccess] = useState({
    situation: false,
    title: null,
  });
  const [search, setSearch] = useState("");

  const [params, setParams] = useState({
    homeId: null,
    advertTypeId: null,
    price: null,
  });

  const [step, setStep] = useState({
    count: 1,
    ratio: "50%",
    information: "Aramak istediğin ilan türü ile başlayalım.",
  });

  const handleIsLogged = async () => {
    try {
      await IsLogged(localStorage.getItem("token"));
    } catch (error) {
      router.push("/login");
    }
  };

  const handleGetHomes = async () => {
    try {
      const data = await GetHomes();
      setCards(data);
      setIsLoading(false);
    } catch (error) {
      setError({
        situation: true,
        text: "Daire listeleme sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  const searchAds = (value) => {
    setSearch(value);
  };

  const selectHome = (id) => {
    setParams((previous) => ({
      ...previous,
      homeId: id,
    }));
    setStep({
      count: 2,
      ratio: "100%",
      information: "Süper! Şimdi de yayınlama bilgilerini girmelisin.",
    });
  };

  const handleCreateAd = async () => {
    try {
      await CreateAd(params);
      setSuccess({
        situation: true,
        title: "İlanınız Başarıyla Oluşturuldu!",
      });
    } catch (error) {
      setError({
        situation: true,
        text: "İlan oluşturma sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  const createAd = () => {
    if (
      params.homeId !== null &&
      params.price !== null &&
      params.advertTypeId !== null
    ) {
      setButtonLoading(true);
      handleCreateAd();
    }
  };

  useEffect(() => {
    handleIsLogged();
    handleGetHomes();
  }, []);

  useEffect(() => {
    const filterCards = () => {
      if (search === "") {
        setFilteredCards(cards);
      } else {
        const filtered = cards.filter((card) =>
          card.title.toLowerCase().includes(search.toLowerCase())
        );
        setFilteredCards(filtered);
      }
    };

    filterCards();
  }, [search, cards]);

  return (
    <>
      {error.situation && <Error text={error.text} />}
      {success.situation && <Success title={success.title} />}
      {isLoading ? (
        <Loading title="Dairelerinizi listeliyorum." />
      ) : (
        <section id="create">
          <div id="create-bar">
            <Bar />
          </div>
          <div id="create-progress">
            <Progress ratio={step.ratio} />
          </div>
          <div id="create-information">
            <Information text={step.information} />
          </div>
          {step.count === 1 && (
            <div id="create-content">
              <div id="create-search">
                <Control
                  type="search"
                  onChangeHandler={(e) => searchAds(e.target.value)}
                />
              </div>
              <div id="create-list">
                {filteredCards.length === 0 ? (
                  <div id="create-empty">
                    <i className="fa-light fa-circle-question"></i>
                    <p>Daire Bulunamadı</p>
                  </div>
                ) : (
                  filteredCards.map((card, index) => (
                    <Card
                      key={index}
                      card={card}
                      onClickHandler={() => selectHome(card.homeId)}
                    ></Card>
                  ))
                )}
              </div>
            </div>
          )}
          {step.count === 2 && (
            <div id="create-form">
              <div id="form-content">
                <div className="form-line">
                  <hr />
                  <h3>Seçili Daire</h3>
                  <hr />
                </div>
                <div id="form-card">
                  {filteredCards.map((card, index) => {
                    if (card.homeId === params.homeId) {
                      return <Card key={index} card={card} />;
                    }
                  })}
                </div>
                <div className="form-line">
                  <hr />
                  <h3>Yayınlama Bilgileri</h3>
                  <hr />
                </div>
                <div id="form-controls">
                  <Control
                    label="İlan Fiyatı"
                    type="number"
                    rule="₺"
                    value={params.price}
                    onChangeHandler={(e) =>
                      setParams((previous) => ({
                        ...previous,
                        price: parseInt(e.target.value),
                      }))
                    }
                  />
                  <Select
                    onSelectHandler={(id) =>
                      setParams((previous) => ({
                        ...previous,
                        advertTypeId: id,
                      }))
                    }
                    label="İlan Türü"
                    options={[
                      {
                        value: 1,
                        text: "Satılık",
                      },
                      {
                        value: 2,
                        text: "Kiralık",
                      },
                    ]}
                  />
                </div>
              </div>
              <div id="form-button">
                <Button
                  text="İlanı Yayınla"
                  onClickHandler={createAd}
                  isLoading={buttonLoading}
                ></Button>
              </div>
            </div>
          )}
        </section>
      )}
    </>
  );
}

export default Create;
