"use client";

import React, { useEffect } from "react";
import { useState } from "react";
import Link from "next/link";
import Loading from "@/components/pages/Loading";
import "@/styles/pages/welcome.scss";

function Welcome() {
  const [isWelcome, setisWelcome] = useState(true);

  useEffect(() => {
    setTimeout(() => {
      setisWelcome(true);
    }, 1000);
  }, []);

  return (
    <>
      {isWelcome ? (
        <section id="welcome">
          <div id="welcome-content">
            <div id="welcome-logo">
              <img src="/logo-icon-light.svg" />
            </div>
            <div id="welcome-title">
              <h1>Merhaba!</h1>
              <p>
                Apsiyon Kâşif platformuna hoş geldin! Ben, Apsiyon gayrimenkul
                dünyasında sizlere rehberlik edecek sanal asistanınızım.
              </p>
              <p>Başlamaya hazır mısın?</p>
            </div>
          </div>
          <div id="welcome-button">
            <Link href="/login">
              <p>Haydi Başlayalım</p>
            </Link>
          </div>
        </section>
      ) : (
        <Loading />
      )}
    </>
  );
}

export default Welcome;
