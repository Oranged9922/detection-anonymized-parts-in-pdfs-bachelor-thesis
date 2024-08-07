﻿using Domain.DocumentAggregate;
using Domain.DocumentAggregate.ValueObjects;

namespace Application.Common.Interfaces.Persistance
{
    /// <summary>
    /// Interface for the document repository
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// Adds a document to the database
        /// </summary>
        /// <param name="document"> The document to add</param>
        /// <returns> The id of the document</returns>
        DocumentId Add(Document document);

        /// <summary>
        /// Gets a document by id
        /// </summary>
        /// <param name="id"> The id of the document</param>
        /// <returns> The document, if in database</returns>

        Document? Get(DocumentId id);
        /// <summary>
        /// Gets a document by document name
        /// </summary>
        /// <param name="documentName"> The name of the document</param>
        /// <returns>The document, if in database</returns>
        Document? Get(string documentName);

        /// <summary>
        ///  Gets a document by hash
        /// </summary>
        /// <param name="hash"> The hash of the document</param>
        /// <returns> The document, if in database</returns>
        Document? GetByHash(string hash);
    }
}
