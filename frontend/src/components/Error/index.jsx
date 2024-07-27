"use client";

import React, { useEffect } from "react";
import "@/styles/components/error.scss";
import { useRouter } from "next/navigation";

function Error(props) {
  const router = useRouter();

  useEffect(() => {
    setTimeout(() => {
      router.push("/guide");
    }, 2000);
  }, []);

  return (
    <section id="error">
      <div id="error-icon">
        <i className="fa-regular fa-circle-exclamation"></i>
      </div>
      <div id="error-title">
        <h3>Bir Hata Oluştu</h3>
        {props.text !== undefined && <p>{props.text}</p>}
      </div>
    </section>
  );
}

export default Error;
