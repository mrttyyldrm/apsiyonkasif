"use client";

import React, { useEffect } from "react";
import "@/styles/components/success.scss";
import { useRouter } from "next/navigation";

function Success(props) {
  const router = useRouter();

  useEffect(() => {
    setTimeout(() => {
      router.push("/guide");
    }, 2000);
  }, []);

  return (
    <section id="success">
      <div id="success-icon">
        <i className="fa-regular fa-circle-exclamation"></i>
      </div>
      <div id="success-title">
        <h3>{props.title}</h3>
        <p>Ana sayfaya yönlendiriliyorsunuz.</p>
      </div>
    </section>
  );
}

export default Success;
