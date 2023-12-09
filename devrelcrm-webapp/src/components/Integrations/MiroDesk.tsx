"use client";

import { useEffect, useState } from "react";
import MiroServiceApi from "@/api/MiroServiceApi";
import MiroBoard from "@/data/MiroBoard";
import { Card, Button, Col, Row } from "react-bootstrap";

const MiroDesk = () => {
  const [boards, setBoards] = useState<MiroBoard[]>([]);
  const [selectedBoard, setSelectedBoard] = useState<MiroBoard | null>(null);

  // Загрузка данных досок при монтировании компонента
  useEffect(() => {
    const fetchMiroBoards = async () => {
      try {
        // Получение списка досок с Miro
        const boardsData: MiroBoard[] = await MiroServiceApi.getBoards();
        setBoards(boardsData);
      
      // Проверка наличия сохраненного идентификатора выбранной доски в локальном хранилище
        // Такая логика выполнена для того, чтобы пользователь попал на доску с которой в последний раз работал
      const savedBoardId = localStorage.getItem('selectedBoardId');
      if (savedBoardId) {
        const selected = boardsData.find((board) => board.id === savedBoardId);
        if (selected) {
          setSelectedBoard(selected);
        }
      }
    } catch (error: any) {
      console.error(error.message);
    }
    };

    fetchMiroBoards();
  }, []);

  const openMiroFrame = (board: MiroBoard) => {
    setSelectedBoard(board);
    localStorage.setItem('selectedBoardId', board.id);
  };

  return (
    <div>
      <h1 className="mb-3 mt-3">Доски Miro</h1>
      <Row xs={1} md={2} lg={3} className="g-4">
        {boards.map((board) => (
          <Col className="card-group" key={board.id}>
            <Card>
              <Card.Img
                height={150}
                variant="top"
                src={board.picture.imageURL}
                alt="Board Preview"
                style={{ objectFit: "cover" }}
              />
              <Card.Body>
                <Card.Title>{board.name}</Card.Title>
                <Card.Text className="text-wrap">{board.description}</Card.Text>
              </Card.Body>
              <Card.Footer>
                <Button
                  variant="outline-dark"
                  onClick={() => openMiroFrame(board)}
                >
                  Открыть доску
                </Button>
              </Card.Footer>
            </Card>
          </Col>
        ))}
      </Row>
      {selectedBoard != null && (
        <iframe
          className="mt-5"
          width="100%"
          height="635"
          src={`https://miro.com/app/live-embed/${selectedBoard.id}/`}
          allow="fullscreen; clipboard-read; clipboard-write"
          allowFullScreen
          title={selectedBoard.name}
        ></iframe>
      )}
    </div>
  );
};

export default MiroDesk;
