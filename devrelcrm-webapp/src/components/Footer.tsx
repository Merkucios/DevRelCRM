import MaxWidthWrapper from './MaxWidthWrapper';
import Link from 'next/link';

const Footer = () => {
  return (
    <>
      <hr className="my-4" />
      <footer className="py-4">
        <MaxWidthWrapper>
          <div className="row align-items-center">
            <div className="col-12 col-md-6 mb-3 mb-md-0">
              <p className="text-sm text-muted text-center text-md-left mb-md-0">
                &copy; {new Date().getFullYear()} Все права защищены
              </p>
            </div>

            <div className="col-12 col-md-6 d-flex justify-content-center justify-content-md-end">
              <div className="d-flex flex-column flex-md-row gap-3">
                <Link href="#" className="text-sm text-muted hover-text-gray-600">
                  Условия использования
                </Link>
                <Link href="#" className="text-sm text-muted hover-text-gray-600">
                  Политика конфиденциальности
                </Link>
                <Link href="#" className="text-sm text-muted hover-text-gray-600">
                  Политика использования файлов cookie
                </Link>
              </div>
            </div>
          </div>
        </MaxWidthWrapper>
      </footer>
    </>
  );
};

export default Footer;
