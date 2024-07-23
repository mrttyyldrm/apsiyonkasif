import React from "react";

function Button(props) {
  return (
    <button
      onClick={props.onClickHandler}
      className={
        props.isActive && props.isActive + props.isLoading && "loading"
      }
    >
      {props.isLoading ? (
        <i class="fa-solid fa-circle-notch fa-spin"></i>
      ) : (
        <p>{props.text}</p>
      )}
    </button>
  );
}

export default Button;
