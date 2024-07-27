"use client";

import React, { useState, useEffect } from "react";
import "@/styles/pages/detail.scss";
import Loading from "@/components/Loading";
import Button from "@/components/Button";
import Error from "@/components/Error";
import Information from "@/components/Information";
import Bar from "@/components/Bar";
import { IsLogged, GetAdDetail } from "@/api";
import { useRouter } from "next/navigation";

function Detail() {
  const router = useRouter();
  const [isLoading, setIsLoading] = useState(true);
  const [isVirtual, setIsVirtual] = useState(false);
  const [details, setDetails] = useState();
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

  const handleGetAdDetail = async (id) => {
    try {
      const data = await GetAdDetail(id);
      setDetails(data);
      setIsLoading(false);
    } catch (error) {
      setError({
        situation: true,
        text: "İlan detay görüntüleme sürecinde bir hata oldu. Lütfen daha sonra tekrar deneyiniz.",
      });
    }
  };

  useEffect(() => {
    handleIsLogged();
    handleGetAdDetail(window.location.href.split("id=")[1]);
  }, []);

  return (
    <>
      {error.situation && <Error text={error.text} />}
      {isVirtual && (
        <section id="virtual">
          <div id="virtual-return" onClick={() => setIsVirtual(false)}>
            <i className="fa-regular fa-circle-chevron-left"></i>
          </div>
          <div id="virtual-content">
            <iframe src={details.tourUrl.url}></iframe>
          </div>
          <div id="virtual-information">
            <Information text="İlanı Sanal Tur ile 3 Boyutlu olarak canlı inceleyebilirsin!" />
          </div>
        </section>
      )}
      {isLoading ? (
        <Loading title="İlan detaylarını görüntülüyorum." />
      ) : (
        <section id="detail">
          <div id="detail-bar">
            <Bar />
          </div>
          <div id="detail-content">
            <article id="detail-images">
              <div id="images-tour" onClick={() => setIsVirtual(true)}>
                <i className="fa-regular fa-360-degrees"></i>
              </div>
              {details.images.map((image, index) => (
                <div
                  className={"image" + (index === 0 ? " showcase" : "")}
                  key={index}
                >
                  <img src={image} />
                </div>
              ))}
            </article>
            <article id="detail-summary">
              <h1>{details.advertTitle.price} ₺</h1>
              <hr />
              <h2>{details.advertTitle.title}</h2>
              <p>
                {details.advertTitle.cityName}, {details.advertTitle.countyName}
              </p>
            </article>
            <article id="detail-properties">
              <h3>İlan Bilgileri</h3>
              <ul id="properties-list">
                <li className="property">
                  <p>İlan Numarası</p>
                  <h4>#{details.advert.advertNumber}</h4>
                </li>
                <li className="property">
                  <p>İlan Tarihi</p>
                  <h4>{details.advert.advertDate}</h4>
                </li>
                <li className="property">
                  <p>İlan Türü</p>
                  <h4>{details.advert.advertType}</h4>
                </li>
                <li className="property">
                  <p>Kat</p>
                  <h4>{details.advert.floor}</h4>
                </li>
                <li className="property">
                  <p>Alan</p>
                  <h4>{details.advert.netArea}</h4>
                </li>
                <li className="property">
                  <p>Oda Sayısı</p>
                  <h4>{details.advert.roomCount}</h4>
                </li>
                <li className="property">
                  <p>Eşya Türü</p>
                  <h4>{details.advert.hasFurnished ? "Eşyalı" : "Eşyasız"}</h4>
                </li>
                <li className="property">
                  <p>Isınma Türü</p>
                  <h4>{details.advert.heatingType}</h4>
                </li>
              </ul>
            </article>
            <article id="detail-invoices">
              <h3>Fatura Bilgileri</h3>
              <ul id="invoices-list">
                {details.billing.invoices.map((invoice, index) => (
                  <li className="invoice">
                    <div className="invoice-icon">
                      <i className={`fa-solid ${invoice.icon}`}></i>
                    </div>
                    <p>{invoice.invoiceTypeName}</p>
                    <h4>
                      {invoice.amount} ₺ <span>/ay</span>
                    </h4>
                  </li>
                ))}
              </ul>
            </article>
            <article id="detail-history">
              <h3>Kira Geçmişi</h3>
              <ul id="history-list">
                {details.history.tenants.map((tenant, index) => (
                  <li className="history" key={index}>
                    <p>{tenant.startDate}</p>
                    <p>{tenant.duration} ay</p>
                    <h5>İlan Kiralandı</h5>
                    <h4>{tenant.price} ₺</h4>
                  </li>
                ))}
              </ul>
            </article>
            <article id="detail-services">
              <h3>Site Hizmetleri</h3>
              <ul id="services-list">
                {details.services.map((service, index) => (
                  <li className="service" key={index}>
                    <i className="fa-solid fa-check"></i>
                    <h4>{service.name}</h4>
                  </li>
                ))}
              </ul>
            </article>
            <article id="detail-map">
              <h3>İlan Konumu</h3>
              <iframe
                src={`https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d12330.866866338387!2d${details.location.longitude}!3d${details.location.latitude}!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1str!2str!4v1722115844830!5m2!1str!2str`}
              ></iframe>
            </article>
            <article id="detail-owner">
              <h3>İlan Sahibi</h3>
              <div id="owner-content">
                <div id="owner-image">
                  <img src={details.owner.image} />
                </div>
                <div id="owner-information">
                  <h4>{details.owner.name}</h4>
                  <div id="owner-contact">
                    <i className="fa-regular fa-phone"></i>
                    <p>{details.owner.number}</p>
                  </div>
                </div>
              </div>
            </article>
          </div>
          <div id="detail-button">
            <Button text="Randevu Al" />
          </div>
        </section>
      )}
    </>
  );
}

export default Detail;
