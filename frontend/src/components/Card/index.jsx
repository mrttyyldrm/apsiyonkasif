import React from "react";

function Card(props) {
  const {
    imageUrl,
    price,
    title,
    cityName,
    countyName,
    features,
    appointmentList,
  } = props.card;

  return (
    <div className="card" onClick={props.onClickHandler}>
      <div className="card-image">
        <img src={imageUrl} />
      </div>
      <div className="card-content">
        {price !== undefined && <h2>{price} ₺</h2>}
        <h3>{title}</h3>
        <p>
          {cityName}, {countyName}
        </p>
      </div>
      {features !== undefined && (
        <ul className="card-features">
          {features.roomCount !== null && (
            <li className="feature">
              <i className="fa-regular fa-grid-2"></i>
              <p>{features.roomCount}</p>
            </li>
          )}
          {features.netArea !== null && (
            <li className="feature">
              <i className="fa-regular fa-square-dashed"></i>
              <p>{features.netArea} m²</p>
            </li>
          )}
          {features.advertTypeName !== null && (
            <li className="feature">
              <i className="fa-regular fa-house-blank"></i>
              <p>{features.advertTypeName}</p>
            </li>
          )}
        </ul>
      )}
      {appointmentList !== undefined && (
        <ul className="card-reservations">
          {appointmentList.map((reservation, index) => (
            <li className="reservation" key={index}>
              <p>{reservation.date}</p>
              <p>{reservation.hours}</p>
              <h4>{reservation.fullName}</h4>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default Card;
