import React from "react";
import { useRouter } from "next/navigation";

function Bar() {
  const router = useRouter();

  const returnGuide = () => {
    router.push("/guide");
  };

  return (
    <>
      <div id="bar-return" onClick={returnGuide}>
        <i className="fa-light fa-circle-chevron-left"></i>
      </div>
      <div id="bar-logo">
        <img src="/logo-light.svg" />
      </div>
    </>
  );
}

export default Bar;
