﻿using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class CreateNotePresenter : Presenter<ICreateNoteView>, ICreateNotePresenter
    {
        private readonly INoteService noteService;
        private readonly INoteDTOFactory noteFactory;

        public CreateNotePresenter(ICreateNoteView view, INoteService noteService, INoteDTOFactory noteFactory)
            : base(view)
        {
            this.View.CreateNewNote += View_CreateNote;

            this.noteService = noteService;
            this.noteFactory = noteFactory;
        }

        private void View_CreateNote(object sender, CreateNoteEventArgs e)
        {
            var note = this.noteFactory.CreateNote(e.Title, e.Content, e.UserId);

            this.noteService.Create(note);
        }
    }
}
