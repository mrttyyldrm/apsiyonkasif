"use client";

import React, { useState } from "react";

function Control(props) {
  const [visibility, setVisibility] = useState({
    icon: "fa-eye",
    type: "password",
  });

  const changeVisibility = () => {
    visibility.icon === "fa-eye"
      ? setVisibility({ icon: "fa-eye-slash", type: "text" })
      : setVisibility({ icon: "fa-eye", type: "password" });
  };

  return (
    <div className="control">
      {props.label !== undefined && <label>{props.label}</label>}
      <div className="control-input">
        {props.type === "search" && (
          <i className="fa-solid fa-magnifying-glass"></i>
        )}
        <input
          type={props.type === "password" ? visibility.type : props.type}
          placeholder={props.placeholder}
          onChange={props.onChangeHandler}
          value={props.value}
        />
        {props.type === "password" ? (
          <i
            className={"fa-regular " + visibility.icon}
            onClick={changeVisibility}
          ></i>
        ) : (
          <p>{props.rule}</p>
        )}
      </div>
    </div>
  );
}

export default Control;
