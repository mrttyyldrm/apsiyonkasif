"use client";

import React, { useState, useEffect } from "react";
import "@/styles/pages/create.scss";
import Loading from "@/components/Loading";
import Information from "@/components/Information";
import Progress from "@/components/Progress";
import Control from "@/components/Control";
import Card from "@/components/Card";
import Error from "@/components/Error";
import { IsLogged } from "@/api";

function Create() {
  const [cards, setCards] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState({
    situation: false,
    text: null,
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

  useEffect(() => {
    handleIsLogged();
  }, []);

  return (
    <>
      {error.situation && <Error text={error.text} />}
      {isLoading ? (
        <Loading title="İlan detaylarını görüntülüyorum." />
      ) : (
        <section id="create">
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
                {cards.map((card, index) => (
                  <Card
                    key={index}
                    card={card}
                    onClickHandler={() => redirectDetails(card.id)}
                  ></Card>
                ))}
              </div>
            </div>
          )}
          {step.count === 2 && <div id="create-form"></div>}
        </section>
      )}
    </>
  );
}

export default Create;
