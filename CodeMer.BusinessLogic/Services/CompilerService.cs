using System.Text;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.BusinessLogicTests;
using CodeMer.Common.DTO.CompilerDto;
using Exception = System.Exception;

namespace CodeMer.BusinessLogic.Services;

public class CompilerService : ICompilerService
{
    public ResponseCompilerDto Compiler(RequestCompilerDto requestCompilerDto)
    {
        var responseCompilerDto = new ResponseCompilerDto();
        
        try
        {
            var filePath = "C:/Users/egor5/OneDrive/Рабочий стол/CodeMer/CodeMer.ProblemMainFiles/Task1.cs";

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(requestCompilerDto.Code);

                fileStream.WriteAsync(buffer, 0, buffer.Length);
            }

            Thread.Sleep(3000);

            var tests = new Tests();
            tests.Test1(5, 2, 7);

            responseCompilerDto.Message = "Success";
            responseCompilerDto.StatusCode = 200;
            
            return responseCompilerDto;
        }
        catch (NUnit.Framework.AssertionException ex)
        {
            responseCompilerDto.Message = ex.Message;
            responseCompilerDto.StatusCode = 200;
            
            return responseCompilerDto;
        }
        catch (Exception ex)
        {
            responseCompilerDto.Message = ex.Message;
            responseCompilerDto.StatusCode = 500;
            
            return responseCompilerDto;
        }
    }
}