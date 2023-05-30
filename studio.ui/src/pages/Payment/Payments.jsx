import React, { useEffect, useState } from "react";
import agent from "../../api/payment_agents";
import "./payments.scss";
import Button from "../../components/Button/Button";

export default function PaymentsTable() {
  const [payments, setPayments] = useState([]);
  const [customerNames, setCustomerNames] = useState({});
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage] = useState(10);
  const [nameFilter, setNameFilter] = useState("");
  const [descriptionFilter, setDescriptionFilter] = useState("");
  const [monthFilter, setMonthFilter] = useState("");

  useEffect(() => {
    agent.Payments.get().then((response) => {
      setPayments(response);
    });

    agent.Customers.get().then((response) => {
      const customerNamesMap = response.reduce((map, customer) => {
        map[customer.customerId] = customer.name;
        return map;
      }, {});

      setCustomerNames(customerNamesMap);
    });
  }, []);

  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  const handleNameFilterChange = (event) => {
    setNameFilter(event.target.value);
    setCurrentPage(1); // Reset to the first page when changing the filter
  };

  const handleDescriptionFilterChange = (event) => {
    setDescriptionFilter(event.target.value);
    setCurrentPage(1); // Reset to the first page when changing the filter
  };

  const handleMonthFilterChange = (event) => {
    setMonthFilter(event.target.value);
    setCurrentPage(1); // Reset to the first page when changing the filter
  };

  const filteredPayments = payments.filter((row) => {
    const customerName = customerNames[row.customerId] || "";
    const description = row.description || "";
    const month = row.month || "";

    return (
      customerName.toLowerCase().includes(nameFilter.toLowerCase()) &&
      description.toLowerCase().includes(descriptionFilter.toLowerCase()) &&
      month.toLowerCase().includes(monthFilter.toLowerCase())
    );
  });

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = filteredPayments.slice(indexOfFirstItem, indexOfLastItem);

  const totalPages = Math.ceil(filteredPayments.length / itemsPerPage);

  return (
    <div className="payments-show">
      <h1>Historia e pagesave</h1>

      <div className="filter-container">
        <input
          type="text"
          placeholder="Name"
          value={nameFilter}
          onChange={handleNameFilterChange}
        />
        <input
          type="text"
          placeholder="Description"
          value={descriptionFilter}
          onChange={handleDescriptionFilterChange}
        />
        <input
          type="text"
          placeholder="Month"
          value={monthFilter}
          onChange={handleMonthFilterChange}
        />
      </div>


      <div className="styled-table">
        <table>
          <thead>
            <tr>
              <th>Studenti</th>
              <th>Përshkrimi</th>
              <th>Shuma</th>
              <th>Muaji</th>
              <th>Data e pagesës</th>
            </tr>
          </thead>

          <tbody>
            {currentItems.map((row) => (
              <tr key={row.id}>
                <th>{customerNames[row.customerId]}</th>
                <th>{row.description}</th>
                <th>{(row.amount * 0.01).toFixed(2)} €</th>
                <th>{row.month}</th>
                <th>
                  {new Date(row.dateOfPayment).toLocaleString("en-GB", {
                    year: "numeric",
                    month: "2-digit",
                    day: "2-digit",
                    hour: "2-digit",
                    minute: "2-digit",
                    second: "2-digit",
                  })}
                </th>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {/* Pagination controls */}
      <div className="pagination">
        <Button
          onClick={() => handlePageChange(currentPage - 1)}
          disabled={currentPage === 1}
          text="Previous"
        />
        <span>{currentPage} / {(totalPages === 0)? 1: totalPages}</span>
        <Button
          onClick={() => handlePageChange(currentPage + 1)}
          disabled={currentPage === totalPages}
          text="Next"
        />
      </div>
    </div>
  );
}