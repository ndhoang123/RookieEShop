import { Link } from "react-router-dom";
import { Nav, NavItem, NavLink } from "reactstrap";
import Footer from "./Footer";

export default function SideBar() {
  return (
    <Nav vertical>
      <NavItem>
        <NavLink>
          <Link className="text-decoration-none" to="/Product">
            Products
          </Link>
        </NavLink>
      </NavItem>
      <NavItem>
        <NavLink>
          <Link className="text-decoration-none" to="/">
            Categories
          </Link>
        </NavLink>
      </NavItem>
      <NavItem>
        <NavLink>
          <Link className="text-decoration-none" to="/User">
            Users
          </Link>
        </NavLink>
      </NavItem>
    </Nav>
  );
}