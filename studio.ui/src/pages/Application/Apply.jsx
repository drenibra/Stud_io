import React from "react";
import { Input } from "../../components/Form/FormComponents";

const Apply = () => {
  return (
    <>
      <h1>Apliko</h1>

      <div className="form-container">
        <Input name="IsSpecialCategory" label="A je kategori speciale?" />
      </div>
    </>
  );
};

export default Apply;
