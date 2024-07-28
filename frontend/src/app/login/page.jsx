"use client";

import React, { useState } from "react";
import "@/styles/pages/login.scss";
import Control from "@/components/Control";
import Button from "@/components/Button";
import Information from "@/components/Information";
import { Auth } from "@/api";
import { useRouter } from "next/navigation";

function Login() {
  const router = useRouter();
  const [datas, setDatas] = useState({
    email: "test@apsiyon.com",
    password: "Apsiyon123.",
  });
  const [loginLoading, setloginLoading] = useState(false);
  const [error, setError] = useState("");

  const handleLogin = async () => {
    if (datas.email !== "" && datas.password !== "" && !loginLoading) {
      setError("");
      setloginLoading(true);

      try {
        const data = await Auth(datas.email, datas.password);
        localStorage.setItem("token", data.token);
        router.push("/guide");
      } catch (error) {
        localStorage.removeItem("token");
        setError(error.message);
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
          <p>
            Mevcut Apsiyon hesabınızla giriş yaparak uygulamayı kullanmaya
            başlayın!
          </p>
        </div>
        <div id="login-controls">
          <Control
            label="E Posta"
            placeholder="E Posta Giriniz"
            type="email"
            value={datas.email}
            onChangeHandler={(e) =>
              setDatas({ email: e.target.value, password: datas.password })
            }
          />
          <Control
            label="Parola"
            placeholder="Parola Giriniz"
            type="password"
            value={datas.password}
            onChangeHandler={(e) =>
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
          onClickHandler={handleLogin}
          isLoading={loginLoading}
        ></Button>
      </div>
    </section>
  );
}

export default Login;
