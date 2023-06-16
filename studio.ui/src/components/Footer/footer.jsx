import "./styles.css";

export default function Footer() {
  return (
    <section className="footer">
      <div className="container">
        {/* <div className="social">
          <a href="#">
            {" "}
            <i className="fab fa-instagram"></i>
          </a>
          <a href="#">
            {" "}
            <i className="fab fa-snapchat"></i>
          </a>
          <a href="#">
            {" "}
            <i className="fab fa-twitter"></i>
          </a>
          <a href="#">
            {" "}
            <i className="fab fa-facebook"></i>
          </a>
        </div> */}
        <ul className="list">
          <li>
            {" "}
            <a href="#">About us </a>{" "}
          </li>
          <li>
            {" "}
            <a href="#"> Terms and conditions </a>{" "}
          </li>
          <li>
            {" "}
            <a href="#"> Privacy Policy </a>{" "}
          </li>
        </ul>
        <p className="copyright" sx={{ color: "white" }}>
          Qendra e Studenteve ©2023
        </p>
      </div>
    </section>
  );
}
