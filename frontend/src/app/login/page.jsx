"use client";

import React, { useState, useEffect } from "react";
import "@/styles/pages/login.scss";
import Control from "@/components/general/Control";
import Button from "@/components/general/Button";
import Information from "@/components/general/Information";
import axios from "axios";

function Login() {
  const [datas, setDatas] = useState({ email: "", password: "" });
  const [loginLoading, setloginLoading] = useState(false);
  const [error, setError] = useState("");

  const loginUser = async (e) => {
    if (datas.email !== "" && datas.password !== "") {
      setError("");
      setloginLoading(true);

      const params = {
        email: datas.email,
        password: datas.password,
      };

      try {
        const response = await axios.post(
          "https://api.mlsadpu.com/auth",
          JSON.stringify(params),
          {
            headers: {
              "Content-Type": "application/json",
            },
          }
        );

        localStorage.setItem("token", response.data.token);

        setDatas({ email: "", password: "" });
        setloginLoading(false);
      } catch (error) {
        localStorage.removeItem("token");

        setError(error.response.data.message);
        setDatas({ email: "", password: "" });
        setloginLoading(false);
      }
    } else {
      setError("Alanlar Boş Bırakılamaz!");
    }
  };

  return (
    <section id="login">
      <div id="login-information">
        <Information text="Öncelikle Apsiyon hesabına giriş yapalım!" />
      </div>
      <div id="login-content">
        <div id="login-title">
          <h1>Giriş Yap</h1>
          <p>Apsiyon platform hesabınızla giriş yaparak kullanmaya başlayın!</p>
        </div>
        <div id="login-controls">
          <Control
            label="E Posta"
            placeholder="E Posta Giriniz"
            type="email"
            value={datas.email}
            onChangeEventHandler={(e) =>
              setDatas({ email: e.target.value, password: datas.password })
            }
          />
          <Control
            label="Parola"
            placeholder="Parola Giriniz"
            type="password"
            value={datas.password}
            onChangeEventHandler={(e) =>
              setDatas({ email: datas.email, password: e.target.value })
            }
          />
        </div>
        {error !== "" && (
          <div id="login-error">
            <p>{error}</p>
          </div>
        )}
      </div>
      <div id="login-button">
        <Button
          text="Giriş Yap"
          onClickHandler={loginUser}
          isLoading={loginLoading}
        ></Button>
      </div>
    </section>
  );
}

export default Login;
