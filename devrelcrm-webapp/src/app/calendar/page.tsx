"use client";

import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import interactionPlugin, {
  Draggable,
  DropArg,
} from "@fullcalendar/interaction";
import timeGridPlugin from "@fullcalendar/timegrid";
import bootstrap5Plugin from "@fullcalendar/bootstrap5";
import { EventSourceInput } from "@fullcalendar/core/index.js";

import { Fragment, useEffect, useState } from "react";
import { Modal, Button } from "react-bootstrap";
import { CheckCircle2, XCircle } from "lucide-react";
import { Event } from "@/data/Calendar/Event";

export default function Calendar() {
  const [events, setEvents] = useState([
    { title: "Организовать созвон 💥", id: "1" },
    { title: "Встреча с лидом 🦸‍♂️", id: "2" },
    { title: "Отправить таск на создание статьи на Хабре 👨‍💻 ", id: "3" },
    { title: "Проанализировать успеваемость 🏅", id: "4" },
    { title: "Проверить мессенджеры ✉️", id: "5" },
  ]);
  const [allEvents, setAllEvents] = useState<Event[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [modalType, setModalType] = useState("");
  const [idToDelete, setIdToDelete] = useState<number | null>(null);
  const [newEvent, setNewEvent] = useState<Event>({
    title: "",
    start: "",
    allDay: false,
    id: 0,
  });

  // Эффект для инициализации перетаскиваемых элементов
  useEffect(() => {
    let draggableEl = document.getElementById("draggable-el");
    if (draggableEl) {
      new Draggable(draggableEl, {
        itemSelector: ".fc-event",
        eventData: function (eventEl) {
          let title = eventEl.getAttribute("title");
          let id = eventEl.getAttribute("data");
          let start = eventEl.getAttribute("start");
          return { title, id, start };
        },
      });
    }
  }, []);

  // Обработчик клика по дате
  function handleDateClick(arg: { date: Date; allDay: boolean }) {
    setNewEvent({
      ...newEvent,
      start: arg.date,
      allDay: arg.allDay,
      id: new Date().getTime(),
    });
    setModalType("addEvent");
    setShowModal(true);
  }
  // Функция добавления события
  function addEvent(data: DropArg) {
    const event = {
      ...newEvent,
      start: data.date.toISOString(),
      title: data.draggedEl.innerText,
      allDay: data.allDay,
      id: new Date().getTime(),
    };
    setAllEvents([...allEvents, event]);
  }
  // Обработчик модального окна для удаления
  function handleDeleteModal(data: { event: { id: string } }) {
    setModalType("deleteEvent");
    setShowModal(true);
    setIdToDelete(Number(data.event.id));
  }
  // Обработчик удаления события
  function handleDelete() {
    setAllEvents(
      allEvents.filter((event) => Number(event.id) !== Number(idToDelete))
    );
    setShowModal(false);
    setIdToDelete(null);
  }
  // Обработчик закрытия модального окна
  function handleCloseModal() {
    setShowModal(false);
    setNewEvent({
      title: "",
      start: "",
      allDay: false,
      id: 0,
    });
    setModalType("");
    setIdToDelete(null);
  }
  // Обработчик изменения поля ввода
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>): void => {
    setNewEvent({
      ...newEvent,
      title: e.target.value,
    });
  };
  // Обработчик отправки формы
  const handleSubmit = (
    e: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ): void => {
    e.preventDefault();
    setAllEvents([...allEvents, newEvent]);
    setShowModal(false);
    setNewEvent({
      title: "",
      start: "",
      allDay: false,
      id: 0,
    });
  };
  // Рендеринг компонента
  return (
    <MaxWidthWrapper>
      <div className="d-flex flex-row mt-5">
        <div className="flex-grow-1">
          {/* Компонент FullCalendar */}
          <FullCalendar
            plugins={[
              dayGridPlugin,
              interactionPlugin,
              timeGridPlugin,
              bootstrap5Plugin,
            ]}
            headerToolbar={{
              start: "dayGridMonth,timeGridWeek,timeGridDay",
              center: "title",
              end: "prevYear,prev,next,nextYear",
            }}
            themeSystem="bootstrap5"
            events={allEvents as EventSourceInput}
            locale="ru"
            nowIndicator={true}
            editable={true}
            droppable={true}
            selectable={true}
            selectMirror={true}
            dateClick={handleDateClick}
            drop={(data) => addEvent(data)}
            eventClick={(data) => handleDeleteModal(data)}
          />
        </div>
        {/* Боковая панель с перетаскиваемыми событиями */}
        <div 
        id="draggable-el" 
        className="bg-light p-3 ms-4 rounded-5"
        style={{ flexShrink: 0, width: '300px' }}
        >
          <h3 className="font-bold text-sm text-center">Мероприятия</h3>
          {events.map((event) => (
            <div
              className="fc-event bg-dark text-wrap text-white p-2 mb-3 rounded text-center"
              title={event.title}
              key={event.id}
            >
              {event.title}
            </div>
          ))}
        </div>
      </div>

      {/* Модальное окно */}
      <Modal show={showModal} onHide={handleCloseModal} centered>
        <Modal.Dialog className="border-0">
          <Modal.Header className="border-0 d-flex flex-column align-items-center">
            {modalType === "addEvent" && (
              <>
                <CheckCircle2 className="text-success" size={48} />
                <Modal.Title className="mt-2">Добавить задачу ✨</Modal.Title>
              </>
            )}
          </Modal.Header>

          <Modal.Body className="border-0">
            {modalType === "addEvent" && (
              <div className="mb-3">
                <input
                  type="text"
                  name="title"
                  className="form-control border-0 border-bottom pb-2"
                  value={newEvent.title}
                  onChange={(e) => handleChange(e)}
                  placeholder="Заголовок"
                />
              </div>
            )}
            {modalType === "deleteEvent" && (
              <div className="text-center">
                <XCircle className="text-danger" size={48} />
                <div className="mt-3 text-center">
                  <p className="text-sm text-gray-500">
                    Вы уверены что хотите удалить запись?
                  </p>
                </div>
              </div>
            )}
          </Modal.Body>

          <Modal.Footer className="border-0 d-flex justify-content-between">
            {modalType === "addEvent" && (
              <Button
                variant="success"
                disabled={newEvent.title === ""}
                onClick={(e: React.MouseEvent<HTMLButtonElement>) =>
                  handleSubmit(e)
                }
              >
                Создать
              </Button>
            )}
            {modalType === "deleteEvent" && (
              <Button variant="danger" onClick={handleDelete}>
                Удалить
              </Button>
            )}
            <Button variant="secondary" onClick={handleCloseModal}>
              Отмена
            </Button>
          </Modal.Footer>
        </Modal.Dialog>
      </Modal>
    </MaxWidthWrapper>
  );
}
