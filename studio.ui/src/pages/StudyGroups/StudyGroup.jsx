import React from "react";
import Headline from "../../assets/study-groups/headline.jpg";

const StudyGroup = () => {
  return (
    <>
      <section className="headline">
        <img
          src={Headline}
          alt="Headline Image"
          style={{ width: "100vw", height: "100%", objectFit: "cover" }}
        />
        <h1 className="headlineImageOverlay">Welcome to Study Groups</h1>
      </section>
    </>
  );
};

export default StudyGroup;
