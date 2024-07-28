"use client";

import React, { useState } from "react";

function Select(props) {
  const [isShow, setIsShow] = useState(false);
  const [selectedOption, setselectedOption] = useState("");

  const selectOption = (id, text) => {
    setIsShow(false);
    setselectedOption(text);
    props.onSelectHandler(id);
  };

  return (
    <div className="select">
      {props.label !== undefined && <label>{props.label}</label>}
      <div className="select-input" onClick={() => setIsShow(true)}>
        <input
          readOnly={true}
          type="text"
          placeholder={props.placeholder}
          onChange={props.onChangeHandler}
          value={selectedOption}
        />
        <i className="fa-regular fa-angle-down"></i>
      </div>
      {props.options !== undefined && isShow && (
        <ul className="select-options">
          {props.options.map((option) => (
            <li
              className="option"
              key={option.value}
              onClick={() => selectOption(option.value, option.text)}
            >
              {option.text}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default Select;
