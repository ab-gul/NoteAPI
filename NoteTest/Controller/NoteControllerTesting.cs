using Azure.Core;
using Castle.Components.DictionaryAdapter;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.Controllers;
using NoteAPI.Domain;
using NoteAPI.DTOs.Notes;
using NoteAPI.ExceptionHandling;
using NoteAPI.Repositories.Abstract;
using NoteAPI.Repositories.Concrete;
using NoteAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoteTest.Controller
{
    public class NoteControllerTesting
    {
        private readonly INoteService _noteService;

        public NoteControllerTesting()
        {
            _noteService = A.Fake<INoteService>();
        }

        [Fact]
        public void GetAllNotes_Returns_Notes()
        {
            //Arrange
            var notes = new List<Note> { new Note(Guid.NewGuid(), Guid.NewGuid(), "", DateTime.UtcNow, DateTime.UtcNow, description: null) };
            var getNoteResponse = notes.Select(note => (GetNoteResponse)note);
            A.CallTo(() => _noteService.GetAllNotesAync()).Returns(notes);
            var controller = new NoteController(_noteService);

            //Act
            var result = (OkObjectResult)controller.GetAllNotesAsync().Result;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            result.StatusCode.Should().Be(200);
            // result.Value.Should().Be(getNoteResponse);
        }

        [Fact]

        public void GetNoteById_WhenNoteFound()
        {
            //Arrange
            var newNote = new List<Note> { new Note(Guid.NewGuid(), Guid.NewGuid(), "", DateTime.UtcNow, DateTime.UtcNow, description: null) };
            var noteId = Guid.NewGuid();
            var getNoteResponse = newNote.Select(newNote => (GetNoteResponse)newNote);
            var controller = new NoteController(_noteService);

            //Act
            var result = (OkObjectResult)controller.GetNoteByIdAsync(noteId).Result;

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.StatusCode.Should().Be(200);

        }
        [Fact]

        public void GetNoteById_WhenNoteNotFound()
        {
            //Arrange
            //var newNote = new List<Note> { new Note(Guid.NewGuid(), Guid.NewGuid(), "", DateTime.UtcNow, DateTime.UtcNow, description: null) };
            Guid noteId = Guid.NewGuid();
            var controller = new NoteController(_noteService);

            //Act and Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.GetNoteByIdAsync(noteId));

        }
        [Fact]
        
        public void CreateNotes_Return_Returns_Success() 
        {
            //Arrange 
            var createdNote = new List<Note> { new Note (Guid.NewGuid(),Guid.NewGuid(), "",DateTime.UtcNow,DateTime.UtcNow, description: null)};
            var getNoteResponse = createdNote.Select(createdNote=> (CreateNoteResponse)createdNote);
            var noteId = Guid.NewGuid(); var noteTitle = string.Empty;
            var controller = new NoteController(_noteService);
           // Act


            // Assert
            Assert.NotEmpty(getNoteResponse);
            Assert.NotNull(getNoteResponse);
            noteTitle.Should().NotBeNull();
            Assert.IsType<Guid>(noteId);
           // Assert.NotEmpty(noteTitle);
            Assert.NotNull(noteTitle);
        }

    }
}
