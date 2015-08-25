var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;

function updateEvent(event, element) {
    //alert(event.description);

    if ($(this).data("qtip")) $(this).qtip("destroy");

    currentUpdateEvent = event;

    $("#eventId").val(event.id);
    $('#updatedialog').dialog('open');
    $("#eventName").val(event.title);
    $("#eventDesc").val(event.description);
    $("#eventPaciente").val(event.pae);
    $("#eventKine").val(event.pro);
    $("#eventOS").val(event.osp);
    $("#eventMonto").val(event.monto);
    
    
    $("#eventStart").text("" + event.start.toLocaleString());

    if (event.end === null) {
        $("#eventEnd").text("");
    }
    else {
        $("#eventEnd").text("" + event.end.toLocaleString());
    }

    return false;
}

function updateSuccess(updateResult) {
    alert(updateResult);
}

function deleteSuccess(deleteResult) {
    alert(deleteResult);
}

function addSuccess(addResult) {
    // if addresult is -1, means event was not added
       alert("Turno agregado: " + addResult);

    //if (addResult != -1) {
    //    $('#calendar').fullCalendar('renderEvent',
	//					{
	//					    title: $("#addEventName").val(),
	//					    start: addStartDate,
	//					    end: addEndDate,
	//					    id: addResult,
	//					    description: $("#addEventDesc").val(),

	//					    pae: $("#addEventPaciente").val(),
	//					    pro: $("#addEventKine").val(),
    //                        osp : $("#addEventOS").val(),
	//					    monto: $("#addEventMonto").val(),
	//					    allDay: globalAllDay
	//					},
	//					true // make the event "stick"
	//				);


    //    $('#calendar').fullCalendar('unselect');
    //}
}

function UpdateTimeSuccess(updateResult) {
    alert(updateResult);
}

function selectDate(start, end, allDay) {

    $('#addDialog').dialog('open');
    $("#addEventStartDate").text("" + start.toLocaleString());
    $("#addEventEndDate").text("" + end.toLocaleString());

    addStartDate = start;
    addEndDate = end;
    globalAllDay = allDay;
    //alert(allDay);
}

function updateEventOnDropResize(event, allDay) {

    var eventToUpdate = {
        id: event.id,
        start: event.start        
    };

    if (event.end === null) {
        eventToUpdate.end = eventToUpdate.start;
    }
    else {
        eventToUpdate.end = event.end;
    }

    var endDate;
    if (!event.allDay) {
        endDate = new Date(eventToUpdate.end + 60 * 60000);
        endDate = endDate.toJSON();
    }
    else {
        endDate = eventToUpdate.end.toJSON();
    }

    eventToUpdate.start = eventToUpdate.start.toJSON();
    eventToUpdate.end = eventToUpdate.end.toJSON(); //endDate;
    eventToUpdate.allDay = event.allDay;

    PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);
}

function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {
    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);
}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {
    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);
}

function checkForSpecialChars(stringToCheck) {
    var pattern = /[^A-Za-z0-9 ]/;
    return pattern.test(stringToCheck);
}

function isAllDay(startDate, endDate) {
    var allDay;

    if (startDate.format("HH:mm:ss") == "00:00:00" && endDate.format("HH:mm:ss") == "00:00:00") {
        allDay = true;
        globalAllDay = true;
    }
    else {
        allDay = false;
        globalAllDay = false;
    }
    return allDay;
}

function qTipText(start, end, pae, pro) {
    var text;

    if (end !== null)
        text = "<strong>Inicio:</strong> " + start.format("MM/DD/YYYY hh:mm T") +
               "<br/><strong>Fin:</strong> " + end.format("MM/DD/YYYY hh:mm T") +
               "<br/><br/><strong>Paciente:</strong>" + pae +
               "<br/><br/><strong>Kinesiólogo:</strong>" + pro;
    else
        text = "<strong>Inicio:</strong> " + start.format("MM/DD/YYYY hh:mm T") +
            "<br/><strong>Fin:</strong>" +
            "<br/><br/><strong>Paciente:</strong>" + pae +
               "<br/><br/><strong>Kinesiólogo:</strong>" + pro;
            

    return text;
}

$(document).ready(function () {
    // update Dialog
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 550,
        buttons: {
            "Actualizar": function () {
                
                var eventToUpdate = {
                    id: currentUpdateEvent.id,
                    title: $("#eventName").val(),
                    description: $("#eventDesc").val(),
                    pae: $("#eventPaciente").val(),
                    pro: $("#eventKine").val(),
                    osp: $("#eventOS").val(),
                    monto: $("#eventMonto").val()

                };

                if (checkForSpecialChars(eventToUpdate.pae)
                 || checkForSpecialChars(eventToUpdate.pro)
                 || checkForSpecialChars(eventToUpdate.monto)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {

                    PageMethods.UpdateEvent(eventToUpdate, updateSuccess);

                    $(this).dialog("close");

                    currentUpdateEvent.title = $("#eventName").val();
                    currentUpdateEvent.description = $("#eventDesc").val();
                    currentUpdateEvent.pae = $("#eventPaciente").val();
                    currentUpdateEvent.pro = $("#eventKine").val();
                    currentUpdateEvent.osp = $("#eventOS").val();
                    currentUpdateEvent.monto = $("#eventMonto").val();
                    

                    $('#calendar').fullCalendar('updateEvent', currentUpdateEvent);
                }

            },
            "Borrar": function () {
                //alert($("#eventId").val());
                if (confirm("¿Desea confirmar la eliminación del turno?")) {

                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                }
            },
            "Cancelar": function () { $(this).dialog("close"); }
        }
    });

    //add dialog
    $('#addDialog').dialog({
        autoOpen: false,
        width: 550,
        buttons: {
            "Agregar": function () {
                //alert("sentado :" + $("#addEventPac").val());

                var eventToAdd = {
                    title: $("#addEventName").val(),
                    description: $("#addEventDesc").val(),
                    
                    start: addStartDate.toJSON(),
                    end: addEndDate.toJSON(),

                    pae: $("#addEventPaciente").val(),
                    pro: $("#addEventKine").val(),
                    osp: $("#addEventOS").val(),
                    monto: $("#addEventMonto").val(),
                    allDay: isAllDay(addStartDate, addEndDate)
                                       
                };

                if (checkForSpecialChars(eventToAdd.title)
                 || checkForSpecialChars(eventToAdd.description)
                 || checkForSpecialChars(eventToAdd.pac)
                 || checkForSpecialChars(eventToAdd.monto)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    //alert("sending " + eventToAdd.pac);
                    PageMethods.AddEvent(eventToAdd, addSuccess);
                    $('#calendar').fullCalendar('renderEvent',eventToAdd,true);
                    $('#calendar').fullCalendar('unselect');
                    $(this).dialog("close");

                }
            },
			"Cancelar": function () {$(this).dialog("close");}
			
        }
    });

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();
    var options = {
        weekday: "long", year: "numeric", month: "short",
        day: "numeric", hour: "2-digit", minute: "2-digit"
    };

    $('#calendar').fullCalendar({
        theme: true,
		header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        defaultView: 'agendaDay',
        eventClick: updateEvent,
        selectable: true,
		selectHelper: true,
		select: selectDate,
		defaultTimedEventDuration: '01:00:00',
		forceEventDuration: true,
		editable: true,
		events: "JsonResponse.ashx",
		minTime: "07:00:00", //8am
		maxTime: "23:00:00", //7am
		eventDrop: eventDropped,
		monthNames: ['Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre'],
		monthNamesShort: ['Ene','Feb','Mar','Abr','May','Jun','Jul','Ago','Sep','Oct','Nov','Dic'],
		dayNames: ['Domingo','Lunes','Martes','Miércoles','Jueves','Viernes','Sábado'],
		dayNamesShort: ['Dom','Lun','Mar','Mié','Jue','Vie','Sáb'],
        eventResize: eventResized,
        eventRender: function (event, element) {
            //alert(event.pac);
            element.qtip({
                content: {
                    text: qTipText(event.start, event.end, event.pae, event.pro),
                    title: '<strong>' + event.pae + '</strong>'
                },
                position: {
                    my: 'bottom left',
                    at: 'top right'
                },
                style: { classes: 'qtip-shadow qtip-rounded' }
            });
        }
    });
});
