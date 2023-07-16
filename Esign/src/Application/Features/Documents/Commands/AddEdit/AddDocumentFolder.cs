﻿using AutoMapper;
using Esign.Application.Interfaces.Repositories;
using Esign.Application.Interfaces.Services;
using Esign.Application.Requests;
using Esign.Domain.Entities.Misc;
using Esign.Shared.Wrapper;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Esign.Application.Features.Documents.Commands.AddEdit
{
    public partial class AddDocumentFolder : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPublic { get; set; } = false;
        [Required]
        public string URL { get; set; }
        [Required]
        public int DocumentTypeId { get; set; }
        public UploadRequest UploadRequest { get; set; }
        public string Client { get; set; }
        public string Value { get; set; }
        public string fileType { get; set; }
        public string keywords { get; set; }
        public bool status { get; set; } 
    }

    internal class AddDocumentFolderHandler : IRequestHandler<AddDocumentFolder, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly IStringLocalizer<AddDocumentFolderHandler> _localizer;

        public AddDocumentFolderHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IUploadService uploadService, IStringLocalizer<AddDocumentFolderHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddDocumentFolder command  , CancellationToken cancellationToken)
        {
            var uploadRequest = command.UploadRequest;
            if (uploadRequest != null)
            {
                uploadRequest.FileName = $"D-{Guid.NewGuid()}{uploadRequest.Extension}";
            }
          
            if (command.Id == 0)
            {
                var doc = _mapper.Map<Document>(command);
                //doc.DocumentTypeId = command.DocumentTypeId;
                //doc.Client = command.Client;
                //doc.Value = command.Value;
                //doc.fileType = command.fileType;
                //doc.keywords = command.keywords;
                //doc.status = command.status;
                if (uploadRequest != null)
                {
                    doc.URL = _uploadService.UploadAsync(uploadRequest);
                }
                await _unitOfWork.Repository<Document>().AddAsync(doc);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(doc.Id, _localizer["Document Saved"]);
            }

            else
            {
                var doc = await _unitOfWork.Repository<Document>().GetByIdAsync(command.Id);
                if (doc != null)
                {
                    doc.Title = command.Title ?? doc.Title;
                    doc.Description = command.Description ?? doc.Description;
                    doc.IsPublic = command.IsPublic;
                    doc.Client = command.Client;
                    doc.Value = command.Value;
                    doc.fileType = command.fileType;
                    doc.keywords = command.keywords;
                    doc.status = command.status;
                    if (uploadRequest != null)
                    {
                        doc.URL = _uploadService.UploadAsync(uploadRequest);
                    }
                    doc.DocumentTypeId = (command.DocumentTypeId == 0) ? doc.DocumentTypeId : command.DocumentTypeId;
                    await _unitOfWork.Repository<Document>().UpdateAsync(doc);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<int>.SuccessAsync(doc.Id, _localizer["Document Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Document Not Found!"]);
                }
            }
        }
    }
}