$(document).ready(function () {
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    $('#Calendar2').fullCalendar({
        editable: true,
        firstDay: 1,
        year: y,
        month: m,
        date: d,
        header: {
            left: 'title',
            right: 'prev,next today,agendaDay,agendaWeek,month'
        },
        //defaultView: 'agendaWeek',
        columnFormat: {
            month: 'ddd',
            week: 'ddd d/M',
            day: 'dddd d/M'
        },
        minTime: 7,
        maxTime: 22,
        allDay: true,
        //editable: true,
        droppable: false,
        slotMinutes: 15,
        disableResizing: false,
        events: [
           {
               "title": "Calendar Test",
               "start": "2015-01-01 18:30:00",
               "end": "2014-06-01 19:00:00",
               "allDay": false
           },
           {
               "title": "Calendar Test 1",
               "start": "2015-02-02 18:30:00",
               "end": "2015-02-02 19:00:00",
               "allDay": false
           },
           {
               "title": "Calendar Test 2",
               "start": "2015-06-03 18:30:00",
               "end": "2015-06-03 19:00:00",
               "allDay": false
           }
        ],
        dayClick: function (date, jsEvent, view) {
            // change the day's background color
            $(this).css('background-color', 'blue');

        },
        eventClick: function (calEvent, jsEvent, view) {

            $(this).css('border-color', 'blue');

        }
    });

});