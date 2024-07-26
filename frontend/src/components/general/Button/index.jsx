import React from "react";

function Button(props) {
  return (
    <button
      onClick={props.onClickHandler}
      className={
        (props.isActive ? "active " : "") + (props.isLoading ? "loading" : "")
      }
    >
      {props.isLoading ? (
        <i className="fa-solid fa-circle-notch fa-spin"></i>
      ) : (
        <p>{props.text}</p>
      )}
    </button>
  );
}

export default Button;
