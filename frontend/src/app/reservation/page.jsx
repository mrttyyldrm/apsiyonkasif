"use client";

import React, { useState, useEffect } from "react";
import "@/styles/pages/reservation.scss";
import Loading from "@/components/Loading";
import Information from "@/components/Information";
import Card from "@/components/Card";
import Error from "@/components/Error";
import Bar from "@/components/Bar";
import { IsLogged, GetReservation } from "@/api";
import { useRouter } from "next/navigation";

function Reservation() {
  const router = useRouter();
  const [cards, setCards] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState({
    situation: false,
    text: null,
  });

  const handleIsLogged = async () => {
    try {
      await IsLogged(localStorage.getItem("token"));
    } catch (error) {
      router.push("/login");
    }
  };

  const handleGetReservation = async () => {
    try {
      const data = await GetReservation();
      setCards(data);
      setIsLoading(false);
    } catch (error) {
      setError({
        situation: true,
        text: "Randevu listeleme sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  useEffect(() => {
    handleIsLogged();
    handleGetReservation();
  }, []);

  const redirectDetails = (id) => {
    router.push(`/detail?id=${id}`);
  };

  return (
    <>
      {error.situation && <Error text={error.text} />}
      {isLoading ? (
        <Loading title="Randevularınızı listeliyorum." />
      ) : (
        <section id="reservation">
          <div id="reservation-bar">
            <Bar />
          </div>
          <div id="reservation-content">
            {cards.length === 0 ? (
              <div id="reservation-empty">
                <i className="fa-light fa-circle-question"></i>
                <p>Randevu Bulunamadı</p>
              </div>
            ) : (
              cards.map((card, index) => (
                <Card
                  key={index}
                  card={card}
                  onClickHandler={() => redirectDetails(card.id)}
                ></Card>
              ))
            )}
          </div>
          <div id="reservation-information">
            <Information text="Mevcut ilanlarınız üzerinden randevularınızı listeledim!" />
          </div>
        </section>
      )}
    </>
  );
}

export default Reservation;
