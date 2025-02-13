import "./Header.css";

const Header = () => {
  return (
    <>
      <div>
        <h1>Welcome to Web Agency AB </h1>
        <p> We offer awesome services for low prices</p>
        <p>
          <img
            src="../src/Assets/web3.jpg"
            alt="web"
            width={500}
            height={300}
          />
        </p>
      </div>
    </>
  );
};
export default Header;
