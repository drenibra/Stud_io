import React, { Children, useEffect, useState } from "react";
import "./Payment.scss";
import agent from "../../api/payment_agents";

const Payment = () => {
  const [pagesa, setPagesa] = useState({
    customerId: "",
    receiptEmail: "fs51701@ubt-uni.net",
    description: "",
    currency: "eur",
    amount: "",
  });

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setPagesa((prev) => {
      return {
        ...prev,
        [name]: value,
        amount: typeOfPayments.find((payment) => payment.type === value)?.price || "",
      };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    agent.Payment.create(pagesa).catch(function (error) {
      console.log(error.response.data);
    });
  };

  const [typeOfPayments, setTypeOfPayments] = useState([]);

  useEffect(() => {
    agent.TypeOfPayments.get().then((response) => {
      setTypeOfPayments(response);
    });
  }, []);

  return (
    <>
      <div className="payment-form">
        <h1>Kryej pagesën</h1>
        <form className="payment-form-group">
          <input
            type="text"
            name="customerId"
            placeholder="Numri personal"
            onChange={handleChange}
          />
          {/* <div className="box">
            <select required>
              <option value="Zgjedh muajin" disabled>
                Zgjedh muajin
              </option>
              <option>Janar</option>
              <option>Shkurt</option>
              <option>Mars</option>
              <option>Prill</option>
              <option>Maj</option>
              <option>Qershor</option>
              <option>Tetor</option>
              <option>Nëntor</option>
              <option>Dhjetor</option>
            </select>
          </div> */}
          <div className="box">
            <select required onChange={handleChange} name="description">
              <option value="Tipi i pagesës" disabled selected>
                Tipi i pagesës
              </option>
              {React.Children.toArray(
                typeOfPayments.map((typeOfPayment) => (
                  <option value={typeOfPayment.type}>
                    {typeOfPayment.type}
                  </option>
                ))
              )}
            </select>
          </div>
          <input
            type="number"
            name="amount"
            placeholder="Shuma për pagesë"
            value={pagesa.amount}
            disabled
          />
          <button
            type="submit"
            value="Submit"
            className="payment-btn"
            onClick={handleSubmit}
          >
            Paguaj
          </button>
        </form>
      </div>
    </>
  );
};

export default Payment;