import React from "react";

function Card(props) {
  const { image, price, title, city, county, roomType, netArea, advertType } =
    props.card;

  return (
    <div className="card" onClick={props.onClickHandler}>
      <div className="card-image">
        <img src={image} />
      </div>
      <div className="card-content">
        <h2>{price} ₺</h2>
        <h3>{title}</h3>
        <p>
          {city}, {county}
        </p>
      </div>
      <ul className="card-features">
        <li className="feature">
          <i className="fa-regular fa-grid-2"></i>
          <p>{roomType}</p>
        </li>
        <li className="feature">
          <i className="fa-regular fa-square-dashed"></i>
          <p>{netArea} m²</p>
        </li>
        <li className="feature">
          <i className="fa-regular fa-house-blank"></i>
          <p>{advertType}</p>
        </li>
      </ul>
    </div>
  );
}

export default Card;
