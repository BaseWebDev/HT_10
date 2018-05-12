﻿using System;

namespace SimpleLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            TF_IDF coef = new TF_IDF();
            coef.Lines = new string[] {
                "Представлен новый открытый фреймворк Asylo, при помощи которого можно легко адаптировать приложения для выноса части функциональности, требующей повышенной защиты, на сторону защищённого анклава(TEE, Trusted Execution Environment).Код фреймворка написан на языке С++ и распространяется под лицензией Apache 2.0.Фреймворк подготовлен компанией Google, но не является официально поддерживаемым продуктом Google.Для упрощения разработки предлагаются образы Docker-контейнеров с реализацией готового сборочного окружения и среды для тестирования работы анклавов.",
                "Использование анклавов подразумевает разбиение приложения на две логические части: небольшой верифицированный защищённый компонент для анклава(например, код для работы с секретными данными) и незащищённый компонент(остальной код приложения).Asylo абстрагирует функциональность анклавов и позволяет создавать переносимые приложения, которые могут быть портированы для разных технологий анклавов без изменения кода программы.Использующая Asylo программа может сохранять возможность изолированного выполнения конфиденциальных вычислений в различных окружениях, в которых применяются аппаратные или программные технологии изоляции.",
                "Для выполнения в анклаве, например, может быть вынесен код для шифрования, аутентификации, работы с конфиденциальными данными, ключами и паролями. В качестве базового набора примитивов шифрования, которые могут использоваться в анклаве, предлагается BoringSSL(форк OpenSSL).Кроме того Asylo предоставляет API для управления анклавом(Enclave Manager, Enclave Client), набор POSIX-функций для применения в анклаве, средства для идентификации и авторизации, API для защищённого ввода / вывода и виртуализации доступа к ФС, поддержку Protocol Buffers и gRPC c протоколом EKEP(Enclave Key Exchange Protocol).",
                "Основными задачами, которые ставятся при использовании анклавов, являются защита выполняемого в анклаве кода от компрометации основной системы и эксплуатации уязвимостей в окружении вне анклава, обеспечение конфиденциальности и целостности хранимой в анклаве информации, гарантия целостности анклава в процессе выполнения кода.Применение анклавов также позволяет защитить приложения, работающие с конфиденциальными данными, от саботажа администраторов или доступа третьих лиц, в условиях применения совместно используемых инфраструктур виртуализации и облачных систем.",
                "Из аппаратных механизмов изоляции в Asylo пока поддерживается только технология Intel SGX. В будущих выпусках обещают добавить поддержку и других систем, таких как ARM TrustZone, AMD PSP(Platform Security Processor) и AMD SEV(Secure Encryption Virtualization).Программные механизмы формирования анклавов основаны на применении технологий виртуализации.",
                "В контексте технологии Intel SGX анклав представляет собой закрытые области памяти, в которых может выполняться код приложений пользовательского уровня, содержимое которых не может быть прочитано и изменено даже ядром и кодом, выполняемым в режимах ring0, SMM и VMM. Передать управление коду в анклаве невозможно традиционными функциями перехода и манипуляциями с регистрами и стеком - для передачи управления в анклав применяется специально созданная новая инструкция, выполняющая проверку полномочий.При этом помещённый в анклав код может применять классические методы вызова для обращения к функциям внутри анклава и специальную инструкцию для вызова внешних функций. Для защиты от аппаратных атак, таких как подключение к модулю DRAM, применяется шифрование памяти анклава."
            };
            var iCoefficients = coef.GetTfidf();
            int i = 0;
            Console.WriteLine("\t Слово: \t Коэффициент TF-IDF");
            foreach (var iCoefficient in iCoefficients ) {
                Console.WriteLine("Документ №"+ i++);
                foreach (var iCoef in iCoefficient) {
                    Console.WriteLine("\t " + iCoef.Key + " \t" + Math.Round(iCoef.Value, 5));
                }
            }
        }
    }
}
