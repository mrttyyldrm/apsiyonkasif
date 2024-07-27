"use client";

import React, { useState, useEffect } from "react";
import "@/styles/pages/listing.scss";
import Information from "@/components/Information";
import Loading from "@/components/Loading";
import Error from "@/components/Error";
import Control from "@/components/Control";
import Bar from "@/components/Bar";
import Card from "@/components/Card";
import { IsLogged, ListAdverts } from "@/api";
import { useRouter } from "next/navigation";

function Listing() {
  const router = useRouter();
  const [isLoading, setIsLoading] = useState(true);
  const [cards, setCards] = useState([]);
  const [filteredCards, setFilteredCards] = useState([]);
  const [error, setError] = useState({
    situation: false,
    text: null,
  });
  const [search, setSearch] = useState("");

  const handleIsLogged = async () => {
    try {
      await IsLogged(localStorage.getItem("token"));
    } catch (error) {
      router.push("/login");
    }
  };

  const handleListAdverts = async (query) => {
    try {
      const data = await ListAdverts(query);
      setCards(data);
      setIsLoading(false);
    } catch (error) {
      setError({
        situation: true,
        text: "İlan listeleme sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  const redirectDetails = (id) => {
    router.push(`/detail?id=${id}`);
  };

  const searchAds = (value) => {
    setSearch(value);
  };

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

  useEffect(() => {
    handleIsLogged();
    handleListAdverts(location.href.split("?")[1]);
  }, []);

  return (
    <>
      {error.situation && <Error text={error.text} />}
      {isLoading ? (
        <Loading
          title="Size en uygun 
      ilanları arıyorum."
        />
      ) : (
        <section id="listing">
          <div id="listing-bar">
            <Bar />
          </div>
          <div id="listing-search">
            <Control
              type="search"
              onChangeHandler={(e) => searchAds(e.target.value)}
            />
          </div>
          <div id="listing-content">
            {filteredCards.length === 0 ? (
              <div id="listing-empty">
                <i className="fa-light fa-circle-question"></i>
                <p>İlan Bulunamadı</p>
              </div>
            ) : (
              filteredCards.map((card, index) => (
                <Card
                  key={index}
                  card={card}
                  onClickHandler={() => redirectDetails(card.id)}
                ></Card>
              ))
            )}
          </div>
          {filteredCards.length !== 0 && (
            <div id="listing-information">
              <Information text="Arama kriterlerinize göre en uygun ilanları listeledim!" />
            </div>
          )}
        </section>
      )}
    </>
  );
}

export default Listing;
