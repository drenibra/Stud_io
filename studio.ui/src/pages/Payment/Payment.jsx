import React, { useEffect, useState } from "react";
import "./Payment.scss";
import Button from "../../components/Button/Button";
import agent from "../../api/payment_agents";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import {
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
} from "@mui/material";

const Payment = () => {
  const [pagesa, setPagesa] = useState({
    customerId: "",
    receiptEmail: "fs51701@ubt-uni.net",
    description: "",
    currency: "eur",
    amount: "",
    month: "",
  });

  const [latestPayment, setLatestPayment] = useState(null);

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setPagesa((prev) => {
      if (name === "month") {
        return {
          ...prev,
          [name]: value,
        };
      } else {
        return {
          ...prev,
          [name]: value,
          amount:
            typeOfPayments.find((payment) => payment.type === value)?.price ||
            "",
        };
      }
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    agent.Payment.create(pagesa)
      .then((newPayment) => {
        setLatestPayment(newPayment);
        toast.success("Pagesa u krye me sukses");
      })
      .catch(function (error) {
        toast.error("Pagesa nuk u realizua!");
      });
  };

  const [typeOfPayments, setTypeOfPayments] = useState([]);

  useEffect(() => {
    agent.TypeOfPayments.get().then((response) => {
      setTypeOfPayments(response);
    });
  }, []);

  const currentDate = new Date();

  const isMonthDisabled = (monthIndex) => {
    const currentMonthIndex = currentDate.getMonth();
    const currentDay = currentDate.getDate();

    const minSelectableDay = 27;
    const maxSelectableDay = 31;

    // Check if the current date falls within the range
    const isWithinRange =
      currentMonthIndex === monthIndex - 1 &&
      currentDay >= minSelectableDay &&
      currentDay <= maxSelectableDay;
    return !isWithinRange;
  };

  return (
    <>
      <></>
      <div className="payment-form">
        <h1>Kryej pagesën</h1>
        <form className="payment-form-group">
          <input
            type="text"
            name="customerId"
            placeholder="Numri personal"
            onChange={handleChange}
          />
          <div className="box">
            <select required onChange={handleChange} name="description">
              <option value="Tipi i pagesës" disabled selected>
                Tipi i pagesës
              </option>
              {typeOfPayments.map((typeOfPayment) => (
                <option value={typeOfPayment.type} key={typeOfPayment.type}>
                  {typeOfPayment.type}
                </option>
              ))}
            </select>
          </div>
          <input
            type="text"
            name="amount"
            placeholder="Shuma për pagesë"
            value={
              pagesa.amount !== ""
                ? `${(pagesa.amount / 100).toFixed(2)} €`
                : ""
            }
            disabled
          />
          <div className="box">
            <select required onChange={handleChange} name="month">
              <option value="Zgjedh muajin" disabled selected>
                Zgjedh muajin
              </option>
              <option disabled={isMonthDisabled(0)}>Janar</option>
              <option disabled={isMonthDisabled(1)}>Shkurt</option>
              <option disabled={isMonthDisabled(2)}>Mars</option>
              <option disabled={isMonthDisabled(3)}>Prill</option>
              <option disabled={isMonthDisabled(4)}>Maj</option>
              <option disabled={isMonthDisabled(5)}>Qershor</option>
              <option disabled={isMonthDisabled(6)}>Korrik</option>
              <option disabled={isMonthDisabled(7)}>Gusht</option>
              <option disabled={isMonthDisabled(8)}>Shtator</option>
              <option disabled={isMonthDisabled(9)}>Tetor</option>
              <option disabled={isMonthDisabled(10)}>Nëntor</option>
              <option disabled={isMonthDisabled(11)}>Dhjetor</option>
            </select>
          </div>

          <Button
            type="submit"
            value="Submit"
            onClick={handleSubmit}
            text="Paguaj"
          />
          <ToastContainer />
        </form>
      </div>

      {latestPayment && (
        <Table>
          <TableHead>
            <TableRow sx={{ background: "#c62828" }}>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Studenti
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Përshkrimi
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Shuma
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Muaji
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Data e pagesës
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            <TableRow key={latestPayment.id}>
              <TableCell>{latestPayment.customerId}</TableCell>
              <TableCell>{latestPayment.description}</TableCell>
              <TableCell>
                {(latestPayment.amount * 0.01).toFixed(2)} €
              </TableCell>
              <TableCell>{latestPayment.month}</TableCell>
              <TableCell>
                {new Date(latestPayment.dateOfPayment).toLocaleString("en-GB", {
                  year: "numeric",
                  month: "2-digit",
                  day: "2-digit",
                  hour: "2-digit",
                  minute: "2-digit",
                  second: "2-digit",
                })}
              </TableCell>
            </TableRow>
          </TableBody>
        </Table>
      )}
    </>
  );
};

export default Payment;
