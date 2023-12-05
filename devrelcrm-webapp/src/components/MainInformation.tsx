import Image from "next/image";
import Link from "next/link";

const MainInformation = () => {
  return (
    <div className="py-20 mx-auto text-center d-flex flex-column align-items-center maxw-3xl">
      <div className="row">
        <div className="col-md-6 mt-5">
          <h1 className="display-4 fw-bold tracking-tight fs-1">
            Дайте волю росту, налаживайте связи со всего света, продвигайте
            уровень своего бренда{" "}
            <span className="text-primary">DevRelCRM</span>.
          </h1>
          <p className="mt-6 text-lg maxw-prose text-muted">
            Вы нашли лучшего компаньона для спокойной и продуктивной работы. В
            нашей платформе вы найдёте необходимые инструменты для продвижения
            бренда компании и познакомитесь с невероятными специалистами мира .
          </p>
          <div className="d-grid gap-2 col-10 col-md-4 mx-auto">
            <Link href="/login" className="btn btn-outline-success btn-lg">
              Регистрация
            </Link>
          </div>
        </div>
        <div className="col-md-6 mt-5">
          <Image
            src="/girl-landing.png"
            alt="Description"
            width={512}
            height={512}
            className="img-fluid"
          />
        </div>
      </div>
    </div>
  );
};

export default MainInformation;
