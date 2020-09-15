using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gera o nome do arquivo com Guid
            //Pega a extensão do arquivo enviado e concatena
            //NomeArquivo  537737251fesbd.png
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //Pega o diretório da aplicação corrente
            //Concante com a pasta que irá salvar o arquivo
            //concatena com o nome do arquivo
            //caminho físico - c://users//User1//aplicacao/upload/imagens/yteygwetewtr.png
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //Gero um objeto FileStream que irá armazenar a minha imagem
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Cópia a imagem para o local informado
            file.CopyTo(streamImagem);

            return "http://localhost:64088/upload/imagens/" + nomeArquivo;
        }
    }
}
