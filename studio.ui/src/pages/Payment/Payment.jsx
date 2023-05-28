import React, { Children, useEffect, useState } from "react";
import "./Payment.scss";
import agent from "../../api/payment_agents";

const Payment = () => {
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
          <input type="text" name="PersonalNo" placeholder="Numri personal" />
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
            <select required>
              <option value="Tipi i pagesës" disabled>
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
          <button type="submit" value="Submit" className="payment-btn">
            Gjenero faturën
          </button>
        </form>
      </div>
    </>
  );
};

export default Payment;
