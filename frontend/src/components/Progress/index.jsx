import React from "react";

function Progress(props) {
  return (
    <>
      <div id="progress-content">
        <div id="progress-bar" style={{ width: props.ratio }}></div>
      </div>
    </>
  );
}

export default Progress;
