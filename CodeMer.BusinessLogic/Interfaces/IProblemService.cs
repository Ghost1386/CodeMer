﻿using CodeMer.Common.DTO.ProblemDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IProblemService
{
    static int ProblemId { get; set; }
    
    void Create(CreateProblemDto createProblemDto);

    List<GetAllProblemDto> GetAll(int userId);

    GetProblemDto Get(int id);

    void Delete(int id);

    void Evaluation(EvaluationProblemDto evaluationProblemDto);
}