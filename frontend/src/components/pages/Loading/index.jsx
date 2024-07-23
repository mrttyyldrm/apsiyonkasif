import React from "react";
import "./style.scss";

function Loading(props) {
  return (
    <section id="loading">
      <div id="loading-logo">
        <img src="/logo-icon-light.svg" />
      </div>
      {props.title !== undefined && <h3>{props.title}</h3>}
    </section>
  );
}

export default Loading;
