-- Запросы к базе данных:
-- 1) Количество выполненных заявок
select count(*) as "Количество выполненных заявок" from application where application.status = "Выполнено";

-- 2) Среднее время выполнения заявки
select  sec_to_time((SUM(time_to_sec(execution_time)) div count(*))) as "avg_time" from application where application.status = "Выполнено";

-- 3) Количество заявок по всем неисправностям 
select type_fault.title as "Неиcправность", count(type_fault) as  "Количество"
from application
join type_fault on application.type_fault = type_fault.idtype_fault
group by type_fault;