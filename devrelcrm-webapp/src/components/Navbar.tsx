import Link from "next/link"
import { Icons } from './Icons'


const Navbar = () => {
    return (
      <nav className="navbar navbar-inverse navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
            <div className="navbar-header">
                <Link href="/" className="navbar-brand">
                    <Icons.logo className="img-fluid" />
                </Link>
            </div>
  
            <ul className="nav navbar-nav">
              <li>
                <Link href="/about" className="nav-link">О нас</Link>
              </li>
            </ul>
            <ul className="nav navbar-nav navbar-right">
                <li className="nav-item">
                    <Link href="/sign-up" className="btn btn-success">
                      Зарегистрироваться
                    </Link>
                </li>
            </ul>
          </div>
      </nav>
    );
  };
  
  export default Navbar;
  