"use client";

import React, { useEffect, useState } from "react";
import Button from "@/components/general/Button";
import "@/styles/pages/guide.scss";
import { IsLogged } from "@/api";
import { useRouter } from "next/navigation";

function Guide() {
  const router = useRouter();
  const [isActives, setIsActives] = useState([false, false, false]);
  const [isSelected, setIsSelected] = useState(false);
  const [messages, setMessages] = useState([
    {
      type: "incoming",
      text: "Apsiyon Kâşif emlak platformuna hoş geldin!",
    },
    {
      type: "incoming",
      text: "Sana nasıl yardımcı olabilirim?",
    },
  ]);

  const selectOption = (route, text) => {
    if (!isSelected) {
      setIsSelected(true);

      const newMessage = {
        type: "outgoing",
        text: text,
      };

      const redirectMessage = {
        type: "incoming",
        text: "Elbette, seni ilgili adıma yönlendiriyorum.",
      };

      setMessages((messages) => [...messages, newMessage]);
      setTimeout(() => {
        setMessages((messages) => [...messages, redirectMessage]);
      }, 500);
      setTimeout(() => {
        router.push("/" + route);
      }, 1500);
    }
  };

  const handleLogged = async () => {
    try {
      await IsLogged(localStorage.getItem("token"));
    } catch (error) {
      router.push("/login");
    }
  };

  useEffect(() => {
    handleLogged();
  }, []);

  return (
    <section id="guide">
      <div id="guide-content">
        <div id="guide-logo">
          <img src="/logo-icon-light.svg" />
        </div>
        <div id="guide-chat">
          {messages.map((message, index) => (
            <div key={index} className={"message " + message.type}>
              <p>{message.text}</p>
            </div>
          ))}
        </div>
      </div>
      <div id="guide-buttons">
        <Button
          isActive={isActives[0]}
          text="İlan oluşturmak istiyorum."
          onClickHandler={() => {
            if (!isSelected) {
              setIsActives([true, false, false]);
              selectOption("create", "İlan oluşturmak istiyorum.");
            }
          }}
        ></Button>
        <Button
          isActive={isActives[1]}
          text="İlan aramak istiyorum."
          onClickHandler={() => {
            if (!isSelected) {
              setIsActives([false, true, false]);
              selectOption("search", "İlan aramak istiyorum.");
            }
          }}
        ></Button>
        <Button
          isActive={isActives[2]}
          text="Rezervasyonlarımı görmek istiyorum."
          onClickHandler={() => {
            if (!isSelected) {
              setIsActives([false, false, true]);
              selectOption(
                "reservation",
                "Rezervasyonlarımı görmek istiyorum."
              );
            }
          }}
        ></Button>
      </div>
    </section>
  );
}

export default Guide;
