import React from "react";

function Information(props) {
  return (
    <>
      <div id="information-logo">
        <img src="/logo-icon-light.svg" />
      </div>
      <div id="information-text">
        <p>{props.text}</p>
      </div>
    </>
  );
}

export default Information;
