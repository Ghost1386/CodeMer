using CodeMer.Common.DTO.CompilerDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface ICompilerService
{
    ResponseCompilerDto Compiler(RequestCompilerDto requestCompilerDto);
}