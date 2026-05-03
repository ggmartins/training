with d as (
    select distinct user_id, record_date
    from sf_events
),
g as (
    select
        user_id,
        record_date,
        record_date - (
            row_number() over (
                partition by user_id
                order by record_date
            ) * interval '1 day'
        ) as streak_start_key
    from d
)
select
    user_id,
    min(record_date) as sdate,
    max(record_date) as edate,
    streak_start_key,
    count(*) as streak_days
from g
group by user_id, streak_start_key
order by streak_days desc, user_id, streak_start_key;
